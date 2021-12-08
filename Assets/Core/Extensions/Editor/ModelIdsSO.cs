using System.Collections.Generic;
using UnityEngine;

namespace Core.Extensions.Editor
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Editor/ModelIdsSO", fileName = "ModelIdsSO")]
    public sealed class ModelIdsSO : ScriptableObject
    {
        [SerializeField] private List<string> _ids;
        [SerializeField] private List<string> _tags;
        public IReadOnlyCollection<string> ModelIds => _ids;
        public IReadOnlyCollection<string> Tags => _tags;
    }
}