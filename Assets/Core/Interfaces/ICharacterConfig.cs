using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        Vector3 StartPosition { get; }
    }
}