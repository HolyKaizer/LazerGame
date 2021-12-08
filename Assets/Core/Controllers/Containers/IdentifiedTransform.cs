using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Controllers.Containers
{
    [Serializable]
    public class IdentifiedTransform 
    {
#if UNITY_EDITOR
        [ValueDropdown("GetModelIds")]
#endif
        [SerializeField] private string _id;
#if UNITY_EDITOR
        [SceneObjectsOnly]
#endif
        [SerializeField] private Transform _transform;
        public string Id => _id;

        public Transform Transform => _transform;
        
#if UNITY_EDITOR
        public void CreatePossibleIds(IEnumerable<string> ids)
        {
            _ids = ids;
        }
        private IEnumerable<string> _ids;
        private IEnumerable<string> GetModelIds() => _ids;
#endif
    }
}