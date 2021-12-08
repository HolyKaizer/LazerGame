using System;
using System.Collections;
using System.Collections.Generic;
using Core.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Core.Management
{
    public class SceneLoader
    {
        private readonly IDictionary<string, AsyncOperationHandle<SceneInstance>> _loaders = new Dictionary<string, AsyncOperationHandle<SceneInstance>>();
        private readonly WaitForEndOfFrame _nextFrame = new WaitForEndOfFrame();
        
        public IEnumerator LoadScenes(IEnumerable<string> sceneNames)
        {
            foreach (var sceneName in sceneNames)
            {
                var loadScene = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                _loaders[sceneName] = loadScene;

                while (!loadScene.IsDone)
                {
                    yield return new WaitForEndOfFrame();
                }
                CustomLogger.Log($"Scene {sceneName} is loaded");
                yield return _nextFrame;
                GC.Collect(2);
                yield return _nextFrame;
            }
        }
        
        public IEnumerator LoadScenes(IEnumerable<AssetReference> sceneAssets)
        {
            foreach (var scene in sceneAssets)
            {
                var loadScene = Addressables.LoadSceneAsync(scene, LoadSceneMode.Additive);
                _loaders[scene.AssetGUID] = loadScene;

                while (!loadScene.IsDone)
                {
                    yield return new WaitForEndOfFrame();
                }
                CustomLogger.Log($"Scene {scene} is loaded");
                yield return _nextFrame;
                GC.Collect(2);
                yield return _nextFrame;
            }
        }
        
        public IEnumerator UnloadScenes(IEnumerable<AssetReference> sceneAssets)
        {
            foreach (var scenes in sceneAssets)
            {
                if (_loaders.TryGetValue(scenes.AssetGUID, out var sceneHandler))
                {
                    _loaders.Remove(scenes.AssetGUID);
                    yield return Addressables.UnloadSceneAsync(sceneHandler);
                    CustomLogger.Log($"Scene {scenes} is unloaded");
                }
            }
        }
        
        public IEnumerator UnloadScenes(IEnumerable<string> sceneNames)
        {
            foreach (var sceneName in sceneNames)
            {
                if (_loaders.TryGetValue(sceneName, out var sceneHandler))
                {
                    _loaders.Remove(sceneName);
                    yield return Addressables.UnloadSceneAsync(sceneHandler);
                    CustomLogger.Log($"Scene {sceneName} is unloaded");
                }
            }
        }

        public async void LoadScenesAsync(IEnumerable<string> sceneNames)
        {
            foreach (var sceneName in sceneNames)
            {
                var loadScene = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                _loaders[sceneName] = loadScene;

                await loadScene.Task;
                CustomLogger.Log($"Scene {sceneName} is loaded");
            }
        }
    }
}