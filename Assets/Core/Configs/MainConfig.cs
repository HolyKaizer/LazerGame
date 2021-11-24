using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/MainConfig", fileName = "MainConfig")]
    public sealed class MainConfig : ScriptableObject, ISerializationCallbackReceiver, IMainConfig
    {
        public InputActionAsset ActionAsset => _actionsAsset;
        [SerializeField] private InputActionAsset _actionsAsset;
        
        [SerializeField] private List<ConfigInfo> _configInfos;
        private IDictionary<string, TypedConfig> _configsDict;
        
        public IEnumerable<string> GetTags() => new[] {"main"};

        public void OnAfterDeserialize()
        {
            if(_configInfos == null || _configInfos.Count == 0) return;

            _configsDict = new Dictionary<string, TypedConfig>(_configInfos.Capacity);
            foreach (var info in _configInfos)
            {
                _configsDict[info.Id] = info.Config;
            }
        }
        
        public IEnumerable<TypedConfig> GetStartConfigs()
        {
            return _configsDict.Values.Where(c => c.GetTags().Contains(Consts.StartTag));
        }
        
        public TConfig GetConfig<TConfig>(string id) where TConfig : IConfig
        {
            if (_configsDict.TryGetValue(id, out var config))
            {
                if (config is TConfig tConfig) return tConfig;
            }
            
            CustomLogger.LogAssertion($"Cannot find log for \"{id}\" ");
            
            return default;
        }
        
        public void OnBeforeSerialize() {}
    }
    
    [Serializable]
    public sealed class ConfigInfo
    {
        public string Id;
        public TypedConfig Config;
    }

    public abstract class NamedConfig : ScriptableObject, INamedConfig
    {
        public abstract string Id { get; }
        public abstract IEnumerable<string> GetTags();
    }

    public abstract class TypedConfig : NamedConfig, ITypedConfig
    {
        public abstract string Type { get; }
    }
}