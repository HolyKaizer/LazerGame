using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    public sealed class LocationController : BaseController
    {
        private readonly IMainSceneContainer _sceneContainer;
        private readonly IContentManager _contentManager;
        private readonly ILocationConfig _config;

        private ILocationContainer _container;

        public LocationController(IMain main, IModel locationModel)
        {
            _contentManager = main.LoaderContext.ContentManager;
            _sceneContainer = main.MainSceneContainer;
            _config = locationModel.GetConfig<ILocationConfig>();
        }
        
        protected override void OnInit()
        {
            _contentManager.BundleLoader.GetAsync<GameObject>(_config.AddressablePrefabId, OnContainerLoaded);
        }
        
        private void OnContainerLoaded(string key, GameObject containerPrefab)
        {
            _container = Object.Instantiate(containerPrefab, _sceneContainer.UiRoot.transform, false).GetComponent<ILocationContainer>();
            _container.LocationRoot.SetSafeActive(true);
        }

        protected override void OnDispose()
        {
            _container = null;
        }
    }
}