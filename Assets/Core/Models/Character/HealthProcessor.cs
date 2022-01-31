using System;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public sealed class HealthProcessor : BaseLogicProcessor<IHealthComponent>, IHealthProcessor
    {
        public event Action<IModel> Died; 
        public override bool IsFixedUpdate => false;

        private readonly ICharacterModel _model;
        private float _curHealth;
        private bool _isDead;
        
        public HealthProcessor(ICharacterModel model) : base(model, model.GetConfig<ICharacterConfig>().GetComponent<IHealthComponent>(Consts.HealthComponent))
        {
            _model = model;
            _curHealth = _storage.GetOrCreate<float>(Consts.Health, _component.StartHeath);
            _isDead = _storage.GetOrCreate<bool>(Consts.IsDead, false);
        }

        protected override void OnUpdate(float dt)
        {
            _curHealth = _storage.Get<float>(Consts.Health);
            if (_curHealth <= 0.0f && !_isDead)
            {
                _isDead = true;
                ConsolidateData();
                Died?.Invoke(_model);
            }
        }

        public override void ConsolidateData()
        {
            _storage.Set(Consts.Health, _curHealth);
            _storage.Set(Consts.IsDead, _isDead);
        }
        
        protected override void OnInit() { }
        protected override void OnDispose() { }
    }
}