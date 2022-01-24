using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models
{
    public abstract class BaseCharacterConfig : TypedConfig, ICharacterConfig, ISerializationCallbackReceiver
    {
        public AssetReference AddressablesPrefab => _addressablePrefab;
        public Vector3 StartPosition => _startPosition;
        public IReadOnlyCollection<ILogicComponent> GetAllComponents() => _componentsDict.Values;

        public T GetComponent<T>(string id) where T : ILogicComponent
        {
            if (_componentsDict.TryGetValue(id, out var component))
            {
                if (component is T tComponent) 
                    return tComponent;
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Model \"{Id}\" cannot cast component \"{component.Id}\" to {typeof(T)} type");
#endif
                return default;
            }
#if LG_DEVELOP
            CustomLogger.LogAssertion($"Cannot find {typeof(T)} component at \"{Id}\" model");
#endif
            return default;
        }
        
        [Space]
        [Title("Character Components")]
        [SerializeField] private List<BaseLogicComponent> _components;
        [Space]
        [Title("Character Prefab")]
        [SerializeField] private AssetReference _addressablePrefab;
        [Title("Initial Location Position")]
        [SerializeField] private Vector3 _startPosition;
        
        private Dictionary<string,ILogicComponent> _componentsDict;
        public void OnAfterDeserialize()
        {
            _componentsDict = new Dictionary<string, ILogicComponent>(_components.Count);
            foreach (var component in _components)
            {
                _componentsDict[component.Id] = component;
            }
        }
        public void OnBeforeSerialize() { }
    }
}