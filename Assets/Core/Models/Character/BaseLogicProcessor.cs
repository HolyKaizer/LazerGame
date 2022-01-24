using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public abstract class BaseLogicProcessor<TComponent> : ILogicProcessor where TComponent : ILogicComponent
    {
        public abstract bool IsFixedUpdate { get; }

        private bool _isInited;
        private bool _isPaused;
        
        protected readonly TComponent _component;
        protected readonly ICharacterStorage _storage;

        protected BaseLogicProcessor(ICharacterModel model, TComponent component)
        {
            _component = component;
            _storage = model.Storage;
        }

        public void Init()
        {
            if(_isInited) return;
            _isInited = true;
            
            OnInit();
        }

        public abstract void ConsolidateData();

        public void Dispose()
        {
            if(_isInited) return;
            _isInited = true;
            
            OnDispose();
        }

        public void Pause()
        {
            if(_isPaused) return;
            _isPaused = true;
            
            OnPause();
        }
        
        public void Update(float dt)
        {
            if(_isPaused || !_isInited) return;
            
            OnUpdate(dt);
        }

        public void FixedUpdate(float fixedDt)
        {
            if(_isPaused|| !_isInited) return;

            OnFixedUpdate(fixedDt);
        }
        
        protected abstract void OnDispose();
        protected abstract void OnInit();

        protected virtual void OnUpdate(float dt) {}
        protected virtual void OnPause() {}

        protected virtual void OnFixedUpdate(float fixedDt){}
    }
}