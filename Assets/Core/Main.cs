using Core.Configs;
using Core.Controllers;
using Core.Input;
using Core.Interfaces;
using Core.Loading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public sealed class Main : MonoBehaviour, IMain
    {
#if LG_DEVELOP
        public bool IsTest => _isTest;
        [SerializeField] private bool _isTest = true;
#endif
        public MainConfig MainConfig => _mainConfig;
        public InputViewModel InputViewModel { get; } = new InputViewModel();

        [SerializeField] private MainConfig _mainConfig;
        
        private ILoaderContext _loaderContext;
        private bool _inited;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
        public void Init(ILoaderContext loaderContext)
        {
            if(_inited) return;
            _inited = true;
            
            _loaderContext = loaderContext;
            
            _loaderContext.EntryGameController.Init();
        }

        private void OnDestroy()
        {
            _inited = false;
            _loaderContext.EntryGameController.Dispose();
        }

    }
}