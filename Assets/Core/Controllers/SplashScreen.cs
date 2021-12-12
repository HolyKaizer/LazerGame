using Core.Interfaces;
using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;

namespace Core.Controllers
{
    public sealed class SplashScreen : BaseController, ISplashScreen 
    {
        public bool IsInited => _isInited;
        
        private readonly ISplashScreenContainer _container;
        private ILoadingProcess _loadingProcess;

        public SplashScreen(ISplashScreenContainer container)
        {
            _container = container;
        }
        
        public void SetProgress(ILoadingProcess loadingProcess)
        {
            _loadingProcess = loadingProcess;
            _container.SetActive(true);
            Init();
        }

        protected override void OnInit()
        {
            if(_loadingProcess == null) return;
            
            if (!_loadingProcess.IsLoadingCompleted)
            {
                _container.SetFill(_loadingProcess.CurLoadingProgress);
            }
            else
            {
                Dispose();
            }
        }

        public void Update(float dt)
        {
            if(!_isInited || _loadingProcess == null) return;
            
            if (!_loadingProcess.IsLoadingCompleted)
            {
                _container.SetFill(_loadingProcess.CurLoadingProgress);
            }
            else
            {
                Dispose();
            }
        }

        protected override void OnDispose()
        {
            _container.SetActive(false);
            _loadingProcess = null;
        }
    }
}