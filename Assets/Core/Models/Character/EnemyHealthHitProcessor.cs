using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public sealed class EnemyHealthHitProcessor : BaseLogicProcessor<IHitHandlerComponent>, IHitHandlerProcessor
    {
        public event HitHandler Hit;
        public override bool IsFixedUpdate => false;
        
        private readonly ICharacterModel _model;

        private bool _wasHit;
        
        private float _curTs;
        private float _lastHitTs;        
        private float _curHealth;

        public EnemyHealthHitProcessor(ICharacterModel model) : base(model, model.GetConfig<ICharacterConfig>().GetComponent<IHitHandlerComponent>(Consts.HitHandlerComponent))
        {
            _model = model;
            var healthComponent = model.GetConfig<ICharacterConfig>().GetComponent<IHealthComponent>(Consts.HealthComponent);
            _curHealth = _storage.GetOrCreate<float>(Consts.Health, healthComponent.StartHeath);
            _lastHitTs = _storage.GetOrCreate<float>(Consts.LastHitTs, 0f);
            _wasHit = _storage.GetOrCreate<bool>(Consts.WasHit, false);
        }

        public void ProcessHit(HitInfo info)
        {
            if (info.Sender.Id.Equals(Consts.PlayerCharacter))
            {
                if (info.Component.IsPeriodicHit)
                {
                    PeriodicHit(info);
                }
                else if(!_wasHit)
                {
                    InstantHit(info);
                }
            }
        }

        private void InstantHit(HitInfo info)
        {
            var prevHealth = _curHealth;
            _curHealth -= info.Component.DamagePerHit;
            _wasHit = true;
            _lastHitTs = _curTs;

            ConsolidateData();
            
            Hit?.Invoke(_model, prevHealth, _curHealth);
        }

        private void PeriodicHit(HitInfo hitInfo)
        {
            if (!_wasHit || _curTs - _lastHitTs >= hitInfo.Component.HitPeriod)
            {
                InstantHit(hitInfo);
            }
        }

        protected override void OnUpdate(float dt)
        {
            _curTs += dt;
        }
        
        public override void ConsolidateData()
        {
            _storage.Set(Consts.Health, _curHealth);
            _storage.Set(Consts.WasHit, _wasHit);
            _storage.Set(Consts.LastHitTs, _lastHitTs);
        }
        
        protected override void OnInit() { }
        protected override void OnDispose() { }
    }
}