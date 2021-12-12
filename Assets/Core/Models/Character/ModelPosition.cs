using UnityEngine;

namespace Core.Models.Character
{
    public sealed class ModelPosition
    {
        private Vector3 _position;

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
    }
}