using System.Collections;
using Core.Configs;
using Core.Interfaces;
using Core.Loading;
using UnityEngine;

namespace Core
{
    public abstract class MainBase : MonoBehaviour, IMain
    {
        public MonoBehaviour MonoBehaviour => this;
        public IMainConfig MainConfig => _mainConfig;
        public InputViewModel InputViewModel { get; } = new InputViewModel();
        public ILoaderContext LoaderContext { get; private set; }
        public ISceneManager SceneManager { get; private set; }

        [SerializeField] private MainConfig _mainConfig;

        protected IGameLoader _gameLoader;

        private void Awake()
        {
            if (CheckOnlyOneMain())
            {
                DontDestroyOnLoad(this);
                SceneManager = new LoadSceneManager(this);
                var context = new LoaderContext();
                LoaderContext = context;
                _gameLoader = new GameLoader(context, this);
            }
        }

        private bool CheckOnlyOneMain()
        {
            return FindObjectsOfType<MainBase>().Length <= 1;
        }

        private void Start()
        {
            if (CheckOnlyOneMain())
            {
                StartCoroutine(StartGameAsync());
            }
            else
            {
                DestroyImmediate(this);
            }
        }
        
        protected abstract IEnumerator StartGameAsync();
        
        protected IEnumerator LoadGame()
        {
            yield return new WaitForEndOfFrame();
            
            yield return StartCoroutine(_gameLoader.Load());
            
            LoaderContext?.EntryGameController?.Init();
        }

        private void OnDestroy()
        {
            LoaderContext?.EntryGameController?.Dispose();
        }
    }
}