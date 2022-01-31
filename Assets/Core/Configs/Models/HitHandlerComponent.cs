using System.Collections.Generic;
using Core.Extensions;
using Core.Extensions.Editor;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/HitHandlerComponent", fileName = "HitHandlerComponent")]
    public sealed class HitHandlerComponent : BaseComponent, IHitHandlerComponent, IHasController
    {
        public override string Id => Consts.HitHandlerComponent;
        public string LogicId => _logicId;
        [Space]
#if UNITY_EDITOR
        [Title("Logic Id")] 
        [ValueDropdown("GetLogicIds")]
#endif
        [SerializeField] private string _logicId;

#if UNITY_EDITOR
        private IEnumerable<string> _ids;

        private void OnEnable()
        {
            var config = AssetDatabase.LoadAssetAtPath<ModelIdsSO>("Assets/Content/Editor/ModelEditorInfos.asset");
            _ids = config.LogicIds;
        }

        private IEnumerable<string> GetLogicIds() => _ids;
#endif
        public string ControllerType => Consts.HitHandler;
    }
}