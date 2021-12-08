using System.Collections.Generic;
using Core.Extensions;
using Core.Extensions.Editor;
using UnityEditor;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public abstract class BaseRootHolderContainer : BaseContainer
    {
        [SerializeField] private IdentifiedTransform[] _transforms;
        private IDictionary<string, Transform> _transformsDict;
            
        protected override void OnAwake()
        {
            _transformsDict = new Dictionary<string, Transform>(_transforms.Length);
            foreach (var identifiedTransform in _transforms)
            {
                _transformsDict[identifiedTransform.Id] = identifiedTransform.Transform;
            }
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            var config = AssetDatabase.LoadAssetAtPath<ModelIdsSO>("Assets/Content/Editor/ModelEditorInfos.asset");
            foreach (var idTransform in _transforms)
            {
                idTransform.CreatePossibleIds(config.ModelIds);
            }
        }
#endif
        public Transform GetContainerRoot(string id)
        {
            if (_transformsDict.TryGetValue(id, out var rootTransform))
            {
                return rootTransform;
            }
#if LG_DEVELOP
            CustomLogger.LogAssertion($"Key=\"{id}\" doesn't contains Root Transform at {gameObject.name}");
#endif
            return default;
        }
    }
}