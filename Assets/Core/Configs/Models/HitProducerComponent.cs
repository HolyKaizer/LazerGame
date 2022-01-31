using Core.Extensions;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/HitProducerComponent", fileName = "HitProducerComponent")]
    public sealed class HitProducerComponent : BaseComponent, IHitProducerComponent
    {
        public override string Id => Consts.HitProducerComponent;

        public float DamagePerHit => _damagePerHit;
        public float HitPeriod => _hitPeriod;
        public bool IsPeriodicHit => _isPeriodicHit;
        
        [SerializeField] private float _damagePerHit;
        [SerializeField] private float _hitPeriod;
        [SerializeField] private bool _isPeriodicHit;
    }
}
