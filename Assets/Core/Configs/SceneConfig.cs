using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "EndlessSoftware/SceneConfig", fileName = "SceneConfig")]
    public class SceneConfig : TypedConfig, ISceneConfig
    {
        public IList<AssetReference> ScenesToLoad => _scenesToLoad;
        public override string Type => Consts.Scene;
        public string LogicId => _logicId;
        
        
        [SerializeField] private AssetReference[] _scenesToLoad;
        [SerializeField] private string _logicId;
    }
}