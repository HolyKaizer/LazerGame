using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    internal class CharacterController : BaseContainerLoaderController<ICharacterContainer>, IUpdatable
    {
        private readonly IMovableCharacter _model;
        private readonly IModelPosition _position;
        
        public CharacterController(IMain main, IRootContainerHolder holder, IMovableCharacter model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
            _model = model;
            _position = model.Storage.Get<IModelPosition>(Consts.Position);
        }

        protected override void OnContainerLoaded()
        {
            Container.MoveTransform.localPosition = _position.Get();
        }

        protected override void OnDispose()
        {
        }

        public void Update(float dt)
        {
            if (!IsContainerLoaded || !_isInited) return;
            
            _model.MoveProcessor.ProcessMove(dt);
            Container.MoveTransform.localPosition = _position.Get();
        }
    }
}