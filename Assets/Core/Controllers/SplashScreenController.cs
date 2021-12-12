using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Controllers
{
    internal class SplashScreenController : BaseContainerLoaderController<ISplashScreenContainer>
    {
        public SplashScreenController(IMain main, Transform containerRoot, IAddressablesPrefabConfig addressablesConfig) : base(main, containerRoot, addressablesConfig)
        {
        }

        protected override void OnContainerLoaded()
        {
            
        }
    }
}