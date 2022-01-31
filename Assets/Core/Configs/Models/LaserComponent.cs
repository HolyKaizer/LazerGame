using Core.Extensions;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/LaserComponent", fileName = "LaserComponent")]
    public sealed class LaserComponent : BaseComponent, ILaserComponent
    {
        public override string Id => Consts.Laser;
        [Title("Move Options")]
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _laserDistance;
        [SerializeField] private Vector3 _playerOffset;
        [Space]
        [Title("Damage Options")]
        [SerializeField] private float _damagePerHit;
        [SerializeField] private float _hitPeriod;
        [SerializeField] private bool _isPeriodicHit;
        
        public float DamagePerHit => _damagePerHit;
        public float HitPeriod => _hitPeriod;
        public bool IsPeriodicHit => _isPeriodicHit;
        
        public float RotationSpeed => _rotationSpeed;
        public float LaserDistance => _laserDistance;
        public Vector3 PlayerOffset => _playerOffset;
    }
}