using Core.Interfaces.Controllers;

namespace Core.Controllers
{
    public abstract class BaseController : IController
    {
        protected bool _isInited { get; private set; }
        
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