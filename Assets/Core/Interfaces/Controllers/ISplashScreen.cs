using Core.Interfaces.Configs;

namespace Core.Interfaces.Controllers
{
    public interface ISplashScreen : IUpdatable
    {
        void SetProgress(ILoadingProcess loadingProcess);
        bool IsInited { get; }
    }
}