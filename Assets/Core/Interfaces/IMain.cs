using Core.Loading;
using UnityEngine;

namespace Core.Interfaces
{
    public interface IMain
    {
        public MonoBehaviour MonoBehaviour { get; }
        IMainConfig MainConfig { get; }
        InputViewModel InputViewModel { get; }
        ILoaderContext LoaderContext { get; }
    }
}