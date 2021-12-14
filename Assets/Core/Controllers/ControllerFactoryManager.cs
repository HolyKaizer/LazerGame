using Core.Extensions;
using Core.Factory;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Models;

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
            Factory.AddVariantFunc<IController>(Consts.Location, objects => new LocationController(objects.GetValue<IMain>(0), objects.GetValue<IRootContainerHolder>(1), objects.GetValue<ILocationModel>(2)));
            Factory.AddVariantFunc<IController>(Consts.LocationObject, objects => new LocationObjectController(objects.GetValue<IMain>(0), objects.GetValue<IRootContainerHolder>(1), objects.GetValue<ILocationObjectModel>(2)));
            Factory.AddVariantFunc<IController>(Consts.Character, objects => new CharacterController(objects.GetValue<IMain>(0), objects.GetValue<IRootContainerHolder>(1), objects.GetValue<ICharacterModel>(2)));
        }
    }
}