using Core.Configs;
using Core.Interfaces;
using Core.Models;
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
        }

        private static void RegisterModels()
        {
            Factory.AddVariantFunc<IModel>("scene", objects => new SceneModel(objects.GetValue<string>(0), objects.GetValue<SceneConfig>(1)));
        }
    }
}