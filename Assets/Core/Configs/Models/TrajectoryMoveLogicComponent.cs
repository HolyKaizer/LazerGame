using Core.Extensions;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/TrajectoryMoveComponent", fileName = "TrajectoryMoveComponent")]
    public sealed class TrajectoryMoveLogicComponent : BaseLogicComponent, ITrajectoryMoveLogicComponent
    {
        public override string Id => Consts.MoveComponent;
        
        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public ILocationTrajectoryConfig Trajectory => _trajectory;
        
        [MinValue(0)]
        [SerializeField] private float _moveSpeed;
        [MinValue(0)]
        [SerializeField] private float _rotationSpeed;
        [Space]
        [SerializeField] private LocationTrajectoryConfig _trajectory;

    }
}