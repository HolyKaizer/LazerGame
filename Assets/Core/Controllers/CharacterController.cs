using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    internal sealed class CharacterController : BaseContainerLoaderController<ICharacterContainer>, IUpdatable
    {
        private readonly ICharacterModel _model;
        private readonly ISerializableVector3 _position;
        private readonly ISerializableVector3 _rotation;

        private readonly IDictionary<IHasController, IController> _obeyControllers = new Dictionary<IHasController, IController>();
        
        private Vector3 _lastPosition;
        
        public CharacterController(IMain main, IRootContainerHolder holder, ICharacterModel model) : base(main, holder.GetContainerRoot(model.Id), model.GetConfig<IAddressablesPrefabConfig>())
        {
            _model = model;
            _position = model.Storage.Get<ISerializableVector3>(Consts.Position);
            _rotation = model.Storage.Get<ISerializableVector3>(Consts.Rotation);
        }

        protected override void OnContainerLoaded()
        {
            Container.MoveTransform.localPosition = _position.Get();
            CreateObeyControllers(_model.GetConfig<ICharacterConfig>().GetAllComponents().OfType<IHasController>());
        }

        private void CreateObeyControllers(IEnumerable<IHasController> hasControllers)
        {
            foreach (var hasController in hasControllers)
            {
                var controller = ControllerFactoryManager.Factory.Build<IController>(hasController.ControllerType, _main, Container, _model);
                controller.Init();
                _obeyControllers.Add(hasController, controller);
            }
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

        protected override void OnDispose()
        {
            base.OnDispose();

            foreach (var controller in _obeyControllers.Values)
                controller.Dispose();
            _obeyControllers.Clear();
        }
    }
}