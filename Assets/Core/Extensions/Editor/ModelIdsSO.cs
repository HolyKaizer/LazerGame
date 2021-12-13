using System.Collections.Generic;
using UnityEngine;

namespace Core.Extensions.Editor
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Editor/ModelIdsSO", fileName = "ModelIdsSO")]
    public sealed class ModelIdsSO : ScriptableObject
    {
        [SerializeField] private List<string> _ids;
        [SerializeField] private List<string> _tags;
        public IEnumerable<string> ModelIds => _ids;
        public IEnumerable<string> Tags => _tags;
    }
}