using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    public sealed class LocationController : BaseContainerLoaderController<ILocationContainer>
    {
        private readonly ILocationModel _locationModel;
        private readonly IDictionary<string, IController> _controllers = new Dictionary<string, IController>();
        
        public LocationController(IMain main, IRootContainerHolder holder, ILocationModel locationModel) : base(main, holder.GetContainerRoot(locationModel.Id), locationModel.GetConfig<IAddressablesPrefabConfig>())
        {
            _locationModel = locationModel;
        }
        
        protected override void OnContainerLoaded()
        {
            Container.LocationRoot.SetSafeActive(true);
            CreateControllers(_locationModel.GetLocationObjects());
            CreateControllers(_locationModel.GetLocationCharacters());
        }

        private void CreateControllers<TModel>(IEnumerable<TModel> collection) where TModel : IModel
        {
            foreach (var model in collection.Where(m => m.GetConfig<IConfig>().GetTags().Contains(Consts.HasController)))
            {
                var controller = model.GetConfig<IAddressablesPrefabConfig>() != null
                    ? ControllerFactoryManager.Factory.Build<IController>(model.GetConfig<ITypedConfig>().Type, _main, Container, model)
                    : ControllerFactoryManager.Factory.Build<IController>(model.GetConfig<ITypedConfig>().Type, _main, model);

                controller.Init();
                _controllers.Add(model.Id, controller);
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            foreach (var controller in _controllers.Values)
            {
                controller.Dispose();
            }
        }
    }
}