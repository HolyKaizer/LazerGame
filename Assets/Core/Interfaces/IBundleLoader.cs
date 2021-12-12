using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Core.Interfaces
{
    public interface IBundleLoader
    {
        IEnumerator LoadForWarmup();
        T Get<T>(string key) where T : Object;
        bool IsLoaded(string key);
        Task<T> GetAsync<T>(string key, Action<string, T> completeCallback = null) where T : Object;
        Task PreloadAsync<T>(string key, Action<string, T> completeCallback) where T : Object;
        void ReleaseAsset(string key);
        (bool, AsyncOperationHandle<Object>) GetHandler(string id);
        T GetComponent<T>(string key) where T : Component;
        void ReleaseAndUnload();
        void Release();
    }
}