using System.Collections.Generic;
using Core.Interfaces;
using UnityEngine;

namespace Core.Configs {
    public abstract class NamedConfig : ScriptableObject, INamedConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private List<string> _tags;
        public string Id => _id;
        public IEnumerable<string> GetTags() => _tags;
    }
}