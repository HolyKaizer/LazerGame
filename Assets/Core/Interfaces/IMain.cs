using Core.Configs;
using Core.Loading;
using UnityEngine;

namespace Core
{
    public interface IMain
    {
        public MonoBehaviour MonoBehaviour { get; }
        IMainConfig MainConfig { get; }
        InputViewModel InputViewModel { get; }
        ILoaderContext LoaderContext { get; }
    }
}