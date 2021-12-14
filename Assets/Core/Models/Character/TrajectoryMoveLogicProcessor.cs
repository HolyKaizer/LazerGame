using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Models.Character
{
    public sealed class TrajectoryMoveLogicProcessor : BaseLogicProcessor
    {
        public override bool IsFixedUpdate => true;
        
        private readonly ITrajectoryMoveLogicComponent _component;
        private readonly ModelPosition _position;

        private int _curPointIndex;
        private Vector3 _nextPoint;
        

        public TrajectoryMoveLogicProcessor(ICharacterModel character)
        {
            _component = character.GetConfig<ICharacterConfig>().GetComponent<ITrajectoryMoveLogicComponent>(Consts.MoveComponent);

            _position = character.Storage.GetOrCreate<ModelPosition>(Consts.Position, character.GetConfig<ICharacterConfig>().StartPosition);
            _curPointIndex = character.Storage.GetOrCreate<int>(Consts.CurPointIndex, 0);
        }

        protected override void OnInit()
        {
        }
        
        protected override void OnFixedUpdate(float fixedDt)
        {
            var pos = _position.Get();
            _nextPoint = _component.Trajectory.MovePoints[Mathf.Min(_component.Trajectory.MovePoints.Count, _curPointIndex + 1)];

            var towards = Vector3.MoveTowards(pos, _nextPoint, 
                fixedDt * _component.MoveSpeed);

            if (pos == _nextPoint)
            {
                _curPointIndex++;
            }

            if (_curPointIndex == _component.Trajectory.MovePoints.Count - 1)
            {
                _curPointIndex = 0;
            }
            
            _position.Set(towards);
        }

        protected override void OnDispose()
        {
        }
    }
}