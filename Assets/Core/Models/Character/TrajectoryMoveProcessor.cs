using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Models.Character
{
    public sealed class TrajectoryMoveProcessor : IMoveProcessor
    {
        private IMovableModel _model;
        private ITrajectoryMoveConfig _trajectoryMoveConfig;

        private int _curPointIndex;
        private Vector3 _curPoint;
        private Vector3 _nextPoint;
        private readonly ModelPosition _position;

        public TrajectoryMoveProcessor(IMovableModel model)
        {
            _model = model;
            _position = model.Storage.GetOrCreate<ModelPosition>(Consts.Position);
            _trajectoryMoveConfig = _model.GetConfig<ITrajectoryMoveConfig>();
        }
        
        public void ProcessMove(float dt)
        {
            _curPoint = _trajectoryMoveConfig.Trajectory.MovePoints[_curPointIndex];
            _nextPoint = _trajectoryMoveConfig.Trajectory.MovePoints[_curPointIndex + 1];

            var position = Vector3.MoveTowards(_curPoint, _nextPoint, 
                dt * _trajectoryMoveConfig.MoveSpeed);
            
        }
    }
}