using System.Collections.Generic;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/SceneConfig", fileName = "SceneConfig")]
    public class SceneConfig : TypedConfig
    {
        public override string Id => _id;

        [SerializeField] private string[] _tags;
        [SerializeField] private string _id;
        
        public override string Type => "scene";
        
        public override IEnumerable<string> GetTags()
        {
            return _tags;
        }

        public List<string> ScenesToLoad;
    }
}