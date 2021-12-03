using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    internal class CharacterController : BaseContainerLoaderController<ICharacterContainer>
    {
        public CharacterController(IMain main, IRootContainerHolder holder, ICharacterModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
        }
        
        protected override void OnInit()
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