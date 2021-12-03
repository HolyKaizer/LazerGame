using Core.Interfaces.Configs;
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
    }
}