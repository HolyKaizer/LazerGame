using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    internal class RotationInputController : BaseController
    {
        
        private readonly ICharacterContainer _container;
        private readonly ISerializableVector3 _rotation;
        private readonly IInputViewModel _inputViewModel;
        
        public RotationInputController(IMain main, ICharacterContainer container, ICharacterModel model)
        {
            _container = container;
            _inputViewModel = main.InputViewModel;
            _rotation = model.Storage.GetOrCreate<ISerializableVector3>(Consts.Rotation, Vector3.zero);
        }

        protected override void OnInit()
        {
            _inputViewModel.RotateInputViewModel.RotateChanged += OnRotationInput;
            _inputViewModel.RotateInputViewModel.RotateEnded += OnRotationEnded;
            _inputViewModel.RotateInputViewModel.RotateStarted += OnRotationStarted;
        }

        private void OnRotationStarted()
        {
        }

        private void OnRotationEnded()
        {
        }

        private void OnRotationInput(Vector2 direction)
        {
            _rotation.Set(direction);
             }

        protected override void OnDispose()
        {
            _inputViewModel.RotateInputViewModel.RotateChanged -= OnRotationInput;
            _inputViewModel.RotateInputViewModel.RotateEnded -= OnRotationEnded;
            _inputViewModel.RotateInputViewModel.RotateStarted -= OnRotationStarted;
        }
    }
}