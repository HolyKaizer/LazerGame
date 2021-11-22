using Core.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Controllers
{
    internal sealed class InputController : BaseController 
    {
        private readonly InputActionMap _playerActions; 
        private readonly RotateInputViewModel _viewModel;
        private const string RotateActionId = "Move";

        public InputController(InputActionMap actionMap, RotateInputViewModel viewModel)
        {
            _playerActions = actionMap;
            _viewModel = viewModel;
            _playerActions.Enable();
        }

        protected override void OnInit()
        {
            var rotate = _playerActions.FindAction(RotateActionId);
            rotate.Enable();
            rotate.started += OnRotateStart;
            rotate.performed += OnMove;
            rotate.canceled += OnRotateEnd;
        }
        
        private void OnRotateStart(InputAction.CallbackContext obj)
        {
            _viewModel.CallRotateStarted();
        }
        
        private void OnRotateEnd(InputAction.CallbackContext obj)
        {
            _viewModel.CallRotateEnded();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            _viewModel.CallRotateChanged(obj.action.ReadValue<Vector2>());
        }

        protected override void OnDispose()
        {
            var rotate = _playerActions.FindAction(RotateActionId);
            rotate.started -= OnRotateStart;
            rotate.performed -= OnMove;
            rotate.canceled -= OnRotateEnd;
        }
    }
}
