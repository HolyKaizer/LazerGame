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
        private readonly ISerializableVector3 _position;
        private readonly ISerializableVector3 _rotation;

        private RotationInputController _rotationInputController;
        private Vector3 _lastPosition;

        public CharacterController(IMain main, IRootContainerHolder holder, ICharacterModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
            _position = model.Storage.Get<ISerializableVector3>(Consts.Position);
            _rotation = model.Storage.Get<ISerializableVector3>(Consts.Rotation);
        }

        protected override void OnContainerLoaded()
        {
            Container.MoveTransform.localPosition = _position.Get();
        }
        
        public void Update(float dt)
        {
            if (!IsContainerLoaded || !_isInited) return;

            Container.MoveTransform.localPosition = _position.Get();

            var currentHalf = UnityHelperExtensions.DirectionToIndex(_rotation.Get(), 2);
            var rightRotationNormalized = currentHalf - 1;
            var scale = Container.MoveTransform.localScale;
            if (!Mathf.Approximately(Mathf.Sign(scale.x), Mathf.Sign(rightRotationNormalized)))
            {
                scale.x *= -1f;
            }

            Container.MoveTransform.localScale = scale;
        }
    }
}