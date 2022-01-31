using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    internal class HitHandlerController : BaseController
    {
        private readonly IHitContainer _container;
        private readonly bool _isHittable;
        
        private readonly IHitHandlerProcessor _hitProcessor;
        
        public HitHandlerController(IMain main, IContainer parentContainer, ICharacterModel model)
        {
            _container = (IHitContainer) parentContainer;
            _isHittable = model.GetConfig<ICharacterConfig>().TryGetComponent<IHitHandlerComponent>(Consts.HitHandlerComponent, out var hitComponent);
            if (_isHittable)
            {
                _hitProcessor = model.GetProcessor<IHitHandlerProcessor>(hitComponent);
            }
        }
        
        protected override void OnInit()
        {
            _container.Hit += OnHit;
        }

        private void OnHit(HitInfo hitInfo)
        {
            if (_isHittable)
            {
                _hitProcessor.ProcessHit(hitInfo);
            }
        }
        
        protected override void OnDispose()
        {
            _container.Hit -= OnHit;
        }
    }
}