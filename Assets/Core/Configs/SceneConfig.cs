using System.Collections.Generic;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/SceneConfig", fileName = "SceneConfig")]
    public class SceneConfig : TypedConfig
    {
        public override string Id => _id;
        public IEnumerable<string> ScenesToLoad => _scenesToLoad;
        public override string Type => "scene";
        public string LogicId => _logicId;
        public override IEnumerable<string> GetTags() => _tags;
        
        [SerializeField] private string[] _tags;
        [SerializeField] private string[] _scenesToLoad;
        [SerializeField] private string _id;
        [SerializeField] private string _logicId;
    }
}