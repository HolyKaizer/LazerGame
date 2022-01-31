using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;
using UnityEngine;

namespace Core.Models
{
    public sealed class SerializableVector3 : ISave, IBuildable, ISerializableVector3
    {
        private Vector3 _value;
        
        public SerializableVector3() { }
        public SerializableVector3(Vector3 value)
        {
            _value = value;
        }

        public void Set(Vector3 position)
        {
            _value = position;
        }

        public Vector3 Get()
        {
            return _value;
        }

        public IDictionary<string, object> Save()
        {
            var save = new Dictionary<string, object>
            {
                [Consts.Type] = Consts.Vector3,
                [Consts.Value] = new List<float> {_value.x, _value.y, _value.z}
            };
            return save;
        }

        public object BuildItem(IDictionary<string, object> rawBuildData)
        {
            _value = rawBuildData.GetVector3(Consts.Value);
            return this;
        }
    }
}