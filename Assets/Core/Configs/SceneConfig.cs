using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/SceneConfig", fileName = "SceneConfig")]
    public class SceneConfig : TypedConfig, ISceneConfig
    {
        public IList<string> ScenesToLoad => _scenesToLoad;
        public override string Type => Consts.Scene;
        public string LogicId => _logicId;
        
        [SerializeField] private string[] _scenesToLoad;
        [SerializeField] private string _logicId;
    }
}