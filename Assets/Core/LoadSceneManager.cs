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
        
        public LoadSceneManager(IMain main)
        {
            _main = main;
        }
        
        public IEnumerator LoadSceneModel(ISceneModel sceneModel)
        { 
            var scenesToLoad = sceneModel.GetConfig<ISceneConfig>().ScenesToLoad;
            
            yield return _main.MonoBehaviour.StartCoroutine(SceneLoader.LoadScenes(scenesToLoad));
            
            sceneModel.InvokeStartLogic(_main);
        }
        
    }
}