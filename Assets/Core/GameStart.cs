using System;
using System.Collections;
using Core.Interfaces;
using Core.Loading;
using UnityEngine;

namespace Core
{
    public sealed class GameStart : MonoBehaviour
    {
        [SerializeField] private Main _main;
        [SerializeField] private bool _isTest = true;
        
        private IGameLoader _gameLoader;
        private ISceneManager _sceneManager;
        private ILoaderContext _loaderContext;
        
        private void Awake()
        {
            var context = new LoaderContext();
            _loaderContext = context;
            _sceneManager = new LoadSceneManager();
            _gameLoader = new GameLoader(context, _main);
        }

        public void Start()
        {
            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {            
            yield return new WaitForEndOfFrame();
            
            yield return StartCoroutine(_gameLoader.Load());

            _main.Init(_loaderContext);
            CustomLogger.LogAssertion("StartCompleted");
        }
    }

    internal class LoadSceneManager : ISceneManager
    {
        public event Action OnSceneLoaded;
        public event Action OnUnloadScene;
        public bool SceneLoading { get; }
        public bool IsGameReady { get; }
        public double StartSwitchLevelTs { get; }
    }
}