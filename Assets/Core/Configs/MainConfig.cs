using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Interfaces.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/MainConfig", fileName = "MainConfig")]
    public sealed class MainConfig : ScriptableObject, ISerializationCallbackReceiver, IMainConfig
    {
        public InputActionAsset ActionAsset => _actionsAsset;
        [SerializeField] private InputActionAsset _actionsAsset;
        
        [SerializeField] private List<TypedConfig> _configInfos;
        private IDictionary<string, TypedConfig> _configsDict;
        
        public HashSet<string> GetTags() => new HashSet<string>{"main"};

        public void OnAfterDeserialize()
        {
            if(_configInfos == null || _configInfos.Count == 0) return;

            _configsDict = new Dictionary<string, TypedConfig>(_configInfos.Capacity);
            foreach (var info in _configInfos)
            {
                if (!string.IsNullOrEmpty(info.Id))
                {
                    _configsDict[info.Id] = info;
                }
            }
        }
        
        public IEnumerable<ITypedConfig> GetStartConfigs()
        {
            return _configInfos.Where(c => c.GetTags().Contains(Consts.Start));
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
}