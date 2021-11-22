using Core.Controllers;
using Core.Input;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actionsAsset;

        private IController _inputController;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            var rotateViewModel = new RotateInputViewModel();
            _inputController = new InputController(_actionsAsset.FindActionMap(Consts.Player), rotateViewModel);
            
            _inputController.Init();
        }
        

        private void OnDestroy()
        {
            _inputController.Dispose();
        }
    }
}