using Core.Controllers;
using Core.Factory;
using Core.Models;

namespace Core
{
    public static class FactoryManager
    {
        private static FactoryBuilder _factory;

        public static void Init()
        {
            _factory = new FactoryBuilder();
            
            ModelFactoryManager.Init(_factory);
            ControllerFactoryManager.Init(_factory);
        }
    }
}