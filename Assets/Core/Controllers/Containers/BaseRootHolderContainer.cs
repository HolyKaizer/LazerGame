using System;
using System.Collections.Generic;
using Core.Extensions;
using UnityEngine;

namespace Core.Controllers.Containers
{
    [Serializable]
    public struct IdentifiedTransform
    {
        [SerializeField] private string _id;
        [SerializeField] private Transform _transform;
        public string Id => _id;
        public Transform Transform => _transform;
    }
    
    public abstract class BaseRootHolderContainer : MonoBehaviour
    {
        [SerializeField] private IdentifiedTransform[] _transforms;
        private IDictionary<string, Transform> _transformsDict;
            
        private void Awake()
        {
            _transformsDict = new Dictionary<string, Transform>(_transforms.Length);
            foreach (var identifiedTransform in _transforms)
            {
                _transformsDict[identifiedTransform.Id] = identifiedTransform.Transform;
            }
        }
    
        public Transform GetContainerRoot(string id)
        {
            if (_transformsDict.TryGetValue(id, out var rootTransform))
            {
                return rootTransform;
            }
#if LG_DEVELOP
            CustomLogger.LogAssertion($"Key=\"{id}\" doesn't contains Root Transform at {gameObject.name}");
            return default;
#endif
        }
    }
}