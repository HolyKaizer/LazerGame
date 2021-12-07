using System.Collections;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Management
{
    public class LoadSceneManager : ILoadSceneManager
    {
        private readonly IMain _main;
        private readonly SceneLoader _sceneLoader;
        private ISceneModel _currentScene;
        
        public LoadSceneManager(IMain main)
        {
            _main = main;
            _sceneLoader = new SceneLoader();
        }
        
        public IEnumerator LoadSceneModel(ISceneModel sceneModel)
        {
            if (_currentScene != null)
            {
                yield return _main.MonoBehaviour.StartCoroutine(_sceneLoader.UnloadScenes(_currentScene.GetConfig<ISceneConfig>().ScenesToLoad));
            }
            _currentScene = sceneModel;
            
            var scenesToLoad = _currentScene.GetConfig<ISceneConfig>().ScenesToLoad;
            
            if (scenesToLoad.Count == 0)
            {
                yield return null;
            }
            else
            {
                yield return _main.MonoBehaviour.StartCoroutine(_sceneLoader.LoadScenes(scenesToLoad));
            }

            yield return new WaitForEndOfFrame();
            
            _currentScene.InvokeStartLogic(_main);
        }
    }
}