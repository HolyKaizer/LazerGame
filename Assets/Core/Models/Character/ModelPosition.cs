using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Models.Character
{
    public sealed class ModelPosition : ISave, IBuildable, IModelPosition
    {
        private Vector3 _position;
        
        public ModelPosition() { }
        public ModelPosition(Vector3 value)
        {
            _position = value;
        }

        public void Set(Vector3 position)
        {
            _position = position;
        }

        public Vector3 Get()
        {
            return _position;
        }

        public IDictionary<string, object> Save()
        {
            var save = new Dictionary<string, object>
            {
                [Consts.Type] = Consts.Position,
                [Consts.Position] = new List<float> {_position.x, _position.y, _position.z}
            };
            return save;
        }

        public object BuildItem(IDictionary<string, object> rawBuildData)
        {
            _position = rawBuildData.GetVector3(Consts.Position);
            return this;
        }
    }
}