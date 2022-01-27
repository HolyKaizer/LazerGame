using Core.Extensions;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/LaserComponent", fileName = "LaserComponent")]
    public sealed class LaserComponent : BaseComponent, ILaserComponent
    {
        public override string Id => Consts.Laser;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _laserDistance;
        [SerializeField] private Vector3 _playerOffset;

        public float RotationSpeed => _rotationSpeed;
        public float LaserDistance => _laserDistance;
        public Vector3 PlayerOffset => _playerOffset;
    }
}