using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Core.Loading
{
    public static class SceneLoader
    {
        private static readonly IDictionary<string, AsyncOperationHandle<SceneInstance>> _loaders = new Dictionary<string, AsyncOperationHandle<SceneInstance>>();
        private static readonly WaitForEndOfFrame _nextFrame = new WaitForEndOfFrame();
        
        public static IEnumerator LoadScenes(IEnumerable<string> sceneNames)
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
        
        public static IEnumerator UnloadScenes(IEnumerable<string> sceneNames)
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
    }
}