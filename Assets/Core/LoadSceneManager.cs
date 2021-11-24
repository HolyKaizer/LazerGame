using System.Collections;
using Core.Configs;
using Core.Interfaces;
using Core.Loading;
using Core.Models;

namespace Core
{
    public class LoadSceneManager : ISceneManager
    {
        private readonly IMain _main;
        private readonly SceneLoader _sceneLoader;
        
        public LoadSceneManager(IMain main)
        {
            _main = main;
            _sceneLoader = new SceneLoader();
        }
        
        public IEnumerator LoadSceneModel(ISceneModel sceneModel)
        { 
            var scenesToLoad = sceneModel.GetConfig<ISceneConfig>().ScenesToLoad;
            
            if (scenesToLoad.Count == 0)
            {
                yield return null;
            }
            else
            {
                yield return _main.MonoBehaviour.StartCoroutine(_sceneLoader.LoadScenes(scenesToLoad));
            }
            
            sceneModel.InvokeStartLogic(_main);
        }
        
    }
}