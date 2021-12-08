using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public abstract class BaseContainer : MonoBehaviour, IContainer
    {
        public GameObject GameObject { get; private set; }
        public Transform Transform { get; private set; }
        
        private void Awake()
        {
            GameObject = gameObject;
            Transform = transform;
            OnAwake();
        }

        protected abstract void OnAwake();
    }
}