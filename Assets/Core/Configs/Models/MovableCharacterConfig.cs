using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/MovableCharacterConfig", fileName = "MovableCharacterConfig")]
    public sealed class MovableCharacterConfig : CharacterConfig, IMovableCharacterConfig
    {
        public override string Type => Consts.MovableCharacter;
        public string MoveType => _moveType;
        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public ILocationTrajectoryConfig Trajectory => _trajectory;
        
        
        [Space]
#if UNITY_EDITOR
        [ValueDropdown("GetMoveTypes")]
#endif
        [SerializeField] private string _moveType;
        [MinValue(0)]
        [SerializeField] private float _moveSpeed;
        [MinValue(0)]
        [SerializeField] private float _rotationSpeed;
        [Space]
        [SerializeField] private LocationTrajectoryConfig _trajectory;

        public IEnumerable<string> GetMoveTypes()
        {
            return new List<string> {Consts.Trajectory};
        }
    }
}