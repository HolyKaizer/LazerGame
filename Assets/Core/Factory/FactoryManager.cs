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
            Factory.AddVariantFunc<ISceneLogic>(Consts.StringEmpty, objects => new EmptySceneLogic(objects.GetValue<IMain>(0)));
            Factory.AddVariantFunc<ISceneLogic>(Consts.StartSceneLogic, objects => new StartGameSceneLogic(objects.GetValue<IMain>(0)));
        }

        private static void RegisterModels()
        {
            Factory.AddVariantFunc<IModel>(Consts.Scene, objects => new SceneModel(objects.GetValue<string>(0), objects.GetValue<ISceneConfig>(1)));
            Factory.AddVariantFunc<IModel>(Consts.Location, objects => new LocationModel(objects.GetValue<string>(0), objects.GetValue<ILocationConfig>(1)));
            Factory.AddVariantFunc<ILocationObjectModel>(Consts.StringEmpty, objects => new SimpleLocationObject(objects.GetValue<string>(0), objects.GetValue<ILocationObjectConfig>(1)));
            Factory.AddVariantFunc<ILocationObjectModel>(Consts.Simple, objects => new SimpleLocationObject(objects.GetValue<string>(0), objects.GetValue<ILocationObjectConfig>(1)));
        }
    }
}