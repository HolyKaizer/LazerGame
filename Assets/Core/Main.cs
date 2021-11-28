using System.Collections;
using Core.Interfaces;
using Core.Models;

namespace Core
{
    public sealed class Main : MainBase
    {
        protected override IEnumerator StartGameAsync()
        {
            yield return LoadGame();
            
            yield return SceneManager.LoadSceneModel((ISceneModel) LoaderContext.UserData.Models["main_scene"]);
            
            CustomLogger.LogAssertion("StartCompleted");
        }
    }
}