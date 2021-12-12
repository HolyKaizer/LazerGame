using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces
{
    public interface IMain
    {
        public MonoBehaviour MonoBehaviour { get; }
        IMainConfig MainConfig { get; }
        IInputViewModel InputViewModel { get; }
        ILoadSceneManager LoadSceneManager { get; }
        ILoaderContext LoaderContext { get; }
        IMainSceneContainer MainSceneContainer { get; }
        IUserData UserData { get; }
        ISplashScreen SplashScreen { get; }
        void CompleteLoadingStep();
    }
}