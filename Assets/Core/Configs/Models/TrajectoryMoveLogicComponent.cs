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
        public override string LogicId => Consts.MoveProcessor;

        public float MoveSpeed => _moveSpeed;
        public ILocationTrajectoryConfig Trajectory => _trajectory;
        
        [MinValue(0)]
        [SerializeField] private float _moveSpeed;
        [Space]
        [SerializeField] private LocationTrajectoryConfig _trajectory;

    }
}