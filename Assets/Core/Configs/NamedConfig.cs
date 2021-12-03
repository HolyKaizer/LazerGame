using System.Collections.Generic;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs {
    public abstract class NamedConfig : ScriptableObject, INamedConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private List<string> _tags;
        private HashSet<string> _tagSet;
        public string Id => _id;
        public HashSet<string> GetTags() => _tagSet ??= new HashSet<string>(_tags);
    }
}