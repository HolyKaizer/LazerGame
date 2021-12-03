using System.Collections;
using Core.Configs;
using Core.Controllers.Containers;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using Core.Loading;
using Core.Management;
using UnityEngine;

namespace Core
{
    public sealed class Main : MonoBehaviour, IMain
    {
        public MonoBehaviour MonoBehaviour => this;
        public IMainConfig MainConfig => _mainConfig;
        public IInputViewModel InputViewModel { get; } = new InputViewModel();
        public ILoaderContext LoaderContext { get; private set; }
        public ILoadSceneManager LoadSceneManager { get; private set; }
        public IMainSceneContainer MainSceneContainer { get; private set; }
        public IUserData UserData => LoaderContext.UserData;

        [SerializeField] private MainConfig _mainConfig;

        private IGameLoader _gameLoader;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            FactoryManager.Init();
            
            LoadSceneManager = new LoadSceneManager(this);
            var context = new LoaderContext();
            LoaderContext = context;
            _gameLoader = new GameLoader(context, this);
        }

        private void Start()
        {
            StartCoroutine(StartGameAsync());
        }
        
        private IEnumerator StartGameAsync()
        {
            yield return StartCoroutine(_gameLoader.Load());
            
            yield return new WaitForEndOfFrame();

            yield return LoadSceneManager.LoadSceneModel((ISceneModel) LoaderContext.UserData.Models["main_scene"]);
            
            yield return new WaitForEndOfFrame();
            
            MainSceneContainer = FindObjectOfType<MainSceneContainer>();

            LoaderContext?.EntryGameController?.Init();

            CustomLogger.LogAssertion("StartCompleted");
        }
        
        private void OnDestroy()
        {
            LoaderContext?.EntryGameController?.Dispose();
        }
    }
}