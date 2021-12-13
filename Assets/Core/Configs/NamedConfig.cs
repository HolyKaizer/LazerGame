using System;
using System.Collections.Generic;
using Core.Extensions.Editor;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Configs 
{
    public abstract class NamedConfig : ScriptableObject, INamedConfig
    {
#if UNITY_EDITOR
        [ValueDropdown("GetModelIds")]
#endif
        [SerializeField] private string _id;
#if UNITY_EDITOR
        [ValueDropdown("GetModelTags", IsUniqueList = true, DropdownTitle = "Select Tag")]
#endif
        [SerializeField] private List<string> _tags;

        public HashSet<string> _tagSet;

        public string Id => _id;

        public HashSet<string> GetTags() => _tagSet ??= new HashSet<string>(_tags);
        
#if UNITY_EDITOR
        private IEnumerable<string> _ids;
        private IEnumerable<string> _tagsToDropdown;

        private void OnEnable()
        {
                var config = AssetDatabase.LoadAssetAtPath<ModelIdsSO>("Assets/Content/Editor/ModelEditorInfos.asset");
                _ids = config.ModelIds;
                _tagsToDropdown = config.Tags;
        }


        private IEnumerable<string> GetModelIds() => _ids;
        private IEnumerable<string> GetModelTags() => _tagsToDropdown;
#endif
    }
}