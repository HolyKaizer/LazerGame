using Core.Interfaces;

namespace Core.Controllers
{
    internal abstract class BaseController : IController
    {
        private bool _isInited;
        
        public void Init()
        {
            if(_isInited) return;
            _isInited = true;

            OnInit();
        }
        
        public void Dispose()
        {
            if(!_isInited) return;
            _isInited = false;
            
            OnDispose();
        }
        
        protected abstract void OnInit();
        protected abstract void OnDispose();
    }
}