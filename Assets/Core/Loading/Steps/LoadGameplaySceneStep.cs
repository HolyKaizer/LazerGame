using System.Collections;
using Core.Configs;

namespace Core.Loading.Steps
{
    internal class LoadGameplaySceneStep : LoadStep
    {
        public LoadGameplaySceneStep(LoaderContext loaderContext, IMain main) : base(loaderContext, main)
        {
        }
        
        public override string StepId => "scene_loading_step";

        protected override IEnumerator OnLoad()
        {
            var sceneModel = _context.UserData.Models["main_scene"];
            
            yield return SceneLoader.LoadScenes(sceneModel.GetConfig<SceneConfig>().ScenesToLoad);;
        }
    }
}