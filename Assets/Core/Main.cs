using System.Collections;
using Core.Configs;
using Core.Controllers.Containers;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;
using Core.Loading;
using Core.Management;
using UnityEngine;

namespace Core
{
    public sealed class Main : MonoBehaviour, IMain, ILoadingProcess
    {
        public MonoBehaviour MonoBehaviour => this;
        public IMainConfig MainConfig => _mainConfig;
        public IInputViewModel InputViewModel { get; } = new InputViewModel();
        public ILoaderContext LoaderContext { get; private set; }       
        public ISplashScreen SplashScreen { get; private set; }
        public ILoadSceneManager LoadSceneManager { get; private set; }
        public IMainSceneContainer MainSceneContainer { get; private set; }
        public IUserData UserData => LoaderContext.UserData;
        public IEngine Engine { get; private set; }

        [SerializeField] private MainConfig _mainConfig;

        private IGameLoader _gameLoader;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            FactoryManager.Init();
            Engine = new Engine();
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

            yield return LoadSceneManager.LoadSceneModel(LoaderContext.UserData.Get<ISceneModel>("main_scene"));
            
            yield return new WaitForEndOfFrame();
            
            MainSceneContainer = FindObjectOfType<MainSceneContainer>();

            LoaderContext?.EntryGameController?.Init();

            SetLoadingComplete();
            CustomLogger.LogAssertion("StartCompleted");
        }

        private void Update()
        {
            if (SplashScreen is {IsInited: true})
                SplashScreen.Update(Time.deltaTime);

            if (IsLoadingCompleted)
            {
                Engine.Update(Time.deltaTime);                
            }
        }

        private void OnDestroy()
        {
            LoaderContext?.EntryGameController?.Dispose();
        }

        #region ILoadingProcess
        
        private int _curCompletedSteps;
        public void SetLoadingComplete()
        {
            IsLoadingCompleted = true;
        }

        public void SetLoadingProgress(float value)
        {
            CurLoadingProgress = value;
        }
        
        public void CompleteLoadingStep()
        {
            _curCompletedSteps++;
            SetLoadingProgress((float)_curCompletedSteps/LoaderContext.StepsCount);
        }
        public bool IsLoadingCompleted { get; private set; }
        public float CurLoadingProgress { get; private set;}

        public void SetSplash(ISplashScreen splashScreen)
        {
            SplashScreen = splashScreen;
        }
        
        #endregion

    }
}