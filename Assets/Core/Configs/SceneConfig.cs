using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
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
        
        [Title("Scenes to load at Start")]
        [SerializeField] private AssetReference[] _scenesToLoad;    
        [Space]
        [Title("Logic type proceed when scene is loaded")]
        [SerializeField] private string _logicId;
    }
}