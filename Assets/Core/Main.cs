using System.Collections;
using Core.Configs;
using Core.Loading;

namespace Core
{
    public sealed class Main : MainBase
    {
        protected override IEnumerator StartGameAsync()
        {
            yield return LoadGame();
            
            var sceneModel = LoaderContext.UserData.Models["main_scene"];
            
            yield return SceneLoader.LoadScenes(sceneModel.GetConfig<SceneConfig>().ScenesToLoad);

            CustomLogger.LogAssertion("StartCompleted");
        }
    }
}