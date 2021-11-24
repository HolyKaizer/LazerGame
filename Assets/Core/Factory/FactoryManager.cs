using Core.Configs;
using Core.Interfaces;
using Core.Models;
using Core.Models.SceneLogic;
using Core.UI;

namespace Core.Factory
{
    public static class FactoryManager
    {
        public static FactoryBuilder Factory { get; private set; }

        public static void Init()
        {
            Factory = new FactoryBuilder();
            RegisterModels();
            RegisterSceneLogics();
        }

        private static void RegisterSceneLogics()
        {
            Factory.AddVariantFunc<ISceneLogic>("", objects => new EmptySceneLogic(objects.GetValue<IMain>(0)));
            Factory.AddVariantFunc<ISceneLogic>("start_scene_logic", objects => new StartGameSceneLogic(objects.GetValue<IMain>(0)));
        }

        private static void RegisterModels()
        {
            Factory.AddVariantFunc<IModel>("scene", objects => new SceneModel(objects.GetValue<string>(0), objects.GetValue<SceneConfig>(1)));
        }
    }
}