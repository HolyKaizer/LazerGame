using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;

namespace Core.Controllers
{
    internal class LocationObjectController : BaseContainerLoaderController<ILocationObjectContainer>
    {
        public LocationObjectController(IMain main, IRootContainerHolder holder, ILocationObjectModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
        }

        protected override void OnContainerLoaded()
        {
        }

        protected override void OnDispose()
        {
        }
    }
}