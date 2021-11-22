using Core.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actionsAsset;
        private IController _inputController;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);

            // GameLoader.LoadGame(this);
            
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