using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Extensions;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Core.Management
{
    public sealed class BundleLoader : IBundleLoader
    {
        private readonly string _name;
        private readonly IDictionary<string, AsyncOperationHandle<Object>> _handles = new Dictionary<string, AsyncOperationHandle<Object>>();

        private bool _loaded;
        private AsyncOperationHandle<Object> _bundleHandler;

        public BundleLoader(string name = "")
        {
            _name = name;
        }

        public IEnumerator LoadForWarmup()
        {
            if (_loaded || string.IsNullOrEmpty(_name))
            {
                yield break;
            }

            _loaded = true;
            
            var counter = 10;

            var fail = false;
            var logsEnabled = false;
            do
            {
                if (counter < 0)
                {
                    yield return null;
                    continue;
                }
                
                _bundleHandler = Addressables.LoadAssetAsync<Object>(_name);
                _bundleHandler.WaitForCompletion();

                if (!_bundleHandler.IsDone)
                    yield return _bundleHandler;

                fail = !_bundleHandler.IsValid() || _bundleHandler.Status != AsyncOperationStatus.Succeeded || _bundleHandler.Result == null;

                counter--;

                if (fail)
                {
                    if (!logsEnabled)
                    {
                        Debug.unityLogger.logEnabled = true;
                        logsEnabled = true;
                    }

                    if (_bundleHandler.IsValid() && _bundleHandler.OperationException != null)
                    {
                        var message = _bundleHandler.OperationException.Message;
                        CustomLogger.LogAssertion($"Bundle load exception: {_name}: {message}");
                    }
                    else CustomLogger.LogAssertion($"Bundle load fail: {_name}");
                    
                    yield return null;
                }
                else
                {
                    if (logsEnabled)
                    {
                        Debug.unityLogger.logEnabled = false;
                        logsEnabled = false;
                    }
                }
            } while (fail);
        }

        public T Get<T>(string key) where T : Object
        {
            var handler = GetLoadHandler<T>(key);
            
            if (!handler.IsDone)
                handler.WaitForCompletion();

            return (T) handler.Result;
        }

        public bool IsLoaded(string key)
        {
            return _handles.TryGetValue(key, out var handle) && handle.IsValid() && handle.IsDone;
        }

        public async Task<T> GetAsync<T>(string key, Action<string, T> completeCallback = null) where T : Object
        {
            var handler = GetLoadHandler<T>(key);
            
            if(!handler.IsDone)
                await handler.Task;
            
            completeCallback?.Invoke(key, (T) handler.Result);

            return (T) handler.Result;
        }
        
        public async Task PreloadAsync<T>(string key, Action<string, T> completeCallback) where T : Object
        {
            var handler = GetLoadHandler<T>(key);
            
            if(!handler.IsDone)
                await handler.Task;
            
            completeCallback?.Invoke(key, (T) handler.Result);
        }

        private AsyncOperationHandle<Object> GetLoadHandler<T>(string key) where T : Object
        {
            if (!_handles.TryGetValue(key, out var handler) || !handler.IsValid())
            {
                if(!handler.IsValid())
                    ReleaseAsset(key);
                
                handler = Addressables.LoadAssetAsync<Object>(key);
                _handles.Add(key, handler);
            }

            return handler;
        }
        
        public void ReleaseAsset(string key)
        {
            if (_handles.TryGetValue(key, out var assetHandle))
            {
                if (assetHandle.IsValid())
                    Addressables.Release(assetHandle);

                _handles.Remove(key);
            }
        }
        
        public T GetComponent<T>(string key) where T : Component
        {
            var go = Get<GameObject>(key);
            return go.GetComponent<T>();
        }

        public void ReleaseAndUnload()
        {
            _loaded = false;
            if (_bundleHandler.IsValid())
                Addressables.Release(_bundleHandler);
            
            Release();
        }

        public (bool, AsyncOperationHandle<Object>) GetHandler(string id)
        {
            if (!_handles.TryGetValue(id, out var handle))
            {
                #if LG_DEVELOP
                CustomLogger.LogAssertion($"Cannot find handler for id =\"{id}\"");
                #endif
                return (false, default);
            }

            return (true, handle);
        }

        public void Release()
        {
            foreach (var handle in _handles.Where(handle => handle.Value.IsValid()))
                Addressables.Release(handle.Value);

            _handles.Clear();
        }
    }
}