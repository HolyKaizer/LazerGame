using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    internal class PlayerController : BaseContainerLoaderController<ICharacterContainer>, IUpdatable
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int RightRotationId = Animator.StringToHash("RightRotationNormalized");

        private readonly ICharacterModel _model;
        private RotationInputController _rotationInputController;
        
        private readonly ISerializableVector3 _position;
        private readonly ISerializableVector3 _rotation;

        private Vector3 _lastPosition;

        public PlayerController(IMain main, IRootContainerHolder holder, ICharacterModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
            _model = model;
            _position = model.Storage.Get<ISerializableVector3>(Consts.Position);
            _rotation = model.Storage.Get<ISerializableVector3>(Consts.Rotation);
        }
        
        protected override void OnContainerLoaded()
        {
            Container.MoveTransform.localPosition = _position.Get();

            _rotationInputController = new RotationInputController(_main, Container, _model);
            _rotationInputController.Init();
        }
        
        public void Update(float dt)
        {
            if (!IsContainerLoaded || !_isInited) return;
            _lastPosition = _position.Get();
            
            Container.Animator.SetBool(IsMoving, true);
            Container.MoveTransform.localPosition = _position.Get();
            
            var currentHalf = UnityHelperExtensions.DirectionToIndex(_rotation.Get(), 8);
            var rightRotationNormalized = (currentHalf - 4) / 4f;
            var scale = Container.MoveTransform.localScale;
            
            if (!Mathf.Approximately(Mathf.Sign(scale.x), Mathf.Sign(rightRotationNormalized)))
            {
                scale.x *= -1f;
            }
            
            Container.MoveTransform.localScale = scale;
            Container.Animator.SetFloat(RightRotationId, Mathf.Abs(rightRotationNormalized));
        }
        
        protected override void OnDispose()
        {
            base.OnDispose();
            
            _rotationInputController?.Dispose();
        }
    }
}