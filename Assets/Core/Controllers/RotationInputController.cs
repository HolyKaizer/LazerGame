using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Controllers
{
    internal class RotationInputController : BaseController
    {
        private readonly ISerializableVector3 _laserRotation;
        private readonly IInputViewModel _inputViewModel;
        
        public RotationInputController(IMain main, ICharacterModel model)
        {
            _inputViewModel = main.InputViewModel;
            _laserRotation = model.Storage.Get<ISerializableVector3>(Consts.LaserRotation);
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
            _laserRotation.Set(direction);
        }

        protected override void OnDispose()
        {
            _inputViewModel.RotateInputViewModel.RotateChanged -= OnRotationInput;
            _inputViewModel.RotateInputViewModel.RotateEnded -= OnRotationEnded;
            _inputViewModel.RotateInputViewModel.RotateStarted -= OnRotationStarted;
        }
    }
}