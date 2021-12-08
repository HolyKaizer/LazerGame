using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class LocationObjectContainer : BaseContainer, ILocationObjectContainer
    {
        [SerializeField] private Vector3 _startOffset;

        public Vector3 StartOffset => _startOffset;
        
        protected override void OnAwake()
        {
            Transform.localPosition += StartOffset;
        }
    }
}