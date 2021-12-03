using Core.Extensions;
using Core.Factory;
using Core.Interfaces;

namespace Core.Controllers
{
    public static class ControllerFactoryManager
    {
        public static FactoryBuilder Factory { get; private set; }
        
        public static void Init(FactoryBuilder factory)
        {
            Factory = factory;
            RegisterControllers();
        }
        
        private static void RegisterControllers()
        {
            Factory.AddVariantFunc<IController>(Consts.Location, objects => new LocationController(objects.GetValue<IMain>(0), objects.GetValue<ILocationModel>(1)));
        }
    }
}