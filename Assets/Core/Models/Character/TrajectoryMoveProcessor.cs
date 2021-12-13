using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Models.Character
{
    public sealed class TrajectoryMoveProcessor : IMoveProcessor
    {
        private readonly ITrajectoryMoveConfig _trajectoryMoveConfig;

        private int _curPointIndex = 0;
        private Vector3 _nextPoint;
        
        private readonly ModelPosition _position;
        private readonly List<Vector3> _movePoints;

        public TrajectoryMoveProcessor(IMovableCharacter character, IDictionary<string, object> rawSave = null)
        {
            _position = character.Storage.GetOrCreate<ModelPosition>(Consts.Position, character.GetConfig<ICharacterConfig>().StartPosition);
            _trajectoryMoveConfig = character.GetConfig<ITrajectoryMoveConfig>();
            _movePoints = _trajectoryMoveConfig.Trajectory.MovePoints;
            
            if (rawSave != null)
            {
                _curPointIndex = rawSave.GetInt(Consts.CurPointIndex);
            }
        }
        
        public void ProcessMove(float dt)
        {
            var pos = _position.Get();
            _nextPoint = _movePoints[Mathf.Min(_movePoints.Count, _curPointIndex + 1)];

            var towards = Vector3.MoveTowards(pos, _nextPoint, 
                dt * _trajectoryMoveConfig.MoveSpeed);

            if (pos == _nextPoint)
            {
                _curPointIndex++;
            }

            if (_curPointIndex == _movePoints.Count - 1)
            {
                _curPointIndex = 0;
            }
            
            _position.Set(towards);
        }

        public IDictionary<string, object> Save()
        {
            var data = new Dictionary<string, object>(1)
            {
                {Consts.CurPointIndex, _curPointIndex}
            };
            return data;
        }
    }
}