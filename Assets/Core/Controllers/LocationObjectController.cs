using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;

namespace Core.Controllers
{
    internal class LocationObjectController : BaseContainerLoaderController<ILocationObjectContainer>
    {
        private readonly ILocationObjectModel _model;

        public LocationObjectController(IMain main, IRootContainerHolder holder, ILocationObjectModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
            _model = model;
        }

        protected override void OnContainerLoaded()
        {
            Container.Transform.localPosition += _model.GetConfig<ILocationObjectConfig>().StartOffset;
        }

        protected override void OnDispose()
        {
        }
    }
}