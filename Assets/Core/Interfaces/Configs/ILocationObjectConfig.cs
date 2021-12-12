using UnityEngine;

namespace Core.Interfaces.Configs 
{
    public interface ILocationObjectConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        Vector3 StartOffset { get; }
    }
}