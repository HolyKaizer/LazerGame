using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Models.Character
{
    public sealed class TrajectoryMoveLogicProcessor : BaseLogicProcessor<ITrajectoryMoveLogicComponent>
    {
        public override bool IsFixedUpdate => false;

        private readonly ISerializableVector3 _position;
        private readonly ISerializableVector3 _rotation;

        private int _curPointIndex;
        private Vector3 _nextPoint;

        public TrajectoryMoveLogicProcessor(ICharacterModel character) : base(character, character.GetConfig<ICharacterConfig>().GetComponent<ITrajectoryMoveLogicComponent>(Consts.MoveComponent))
        {
            _position = _storage.GetOrCreate<ISerializableVector3>(Consts.Position, character.GetConfig<ICharacterConfig>().StartPosition);
            _rotation = _storage.GetOrCreate<ISerializableVector3>(Consts.Rotation, Vector3.zero);

            _curPointIndex = _storage.GetOrCreate<int>(Consts.CurPointIndex, 0);
        }
        
        public override void ConsolidateData()
        {
            _storage.Set(Consts.CurPointIndex, _curPointIndex);
        }
        
        protected override void OnUpdate(float dt)
        {
            var pos = _position.Get();
            _nextPoint = _component.Trajectory.MovePoints[Mathf.Min(_component.Trajectory.MovePoints.Count - 1, _curPointIndex + 1)];
            var towards = Vector3.MoveTowards(pos, _nextPoint, dt * _component.MoveSpeed);
            if (pos == _nextPoint)
            {
                _curPointIndex++;
                ConsolidateData();
            }

            if (_curPointIndex >= _component.Trajectory.MovePoints.Count - 1)
            {
                _curPointIndex = 0;
                ConsolidateData();
            }
            
            var direction = RecalculateDirection();

            _rotation.Set(direction);
            _position.Set(towards);
        }

        private Vector3 RecalculateDirection()
        {
            var nextPoint = _component.Trajectory.MovePoints[Mathf.Min(_component.Trajectory.MovePoints.Count - 1, _curPointIndex + 1)];
            return (nextPoint - _position.Get()).normalized; 
        }

        protected override void OnInit() { }
        protected override void OnDispose() { }
    }
}