using System.Collections.Generic;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        Vector3 StartPosition { get; }
        T GetComponent<T>(string id) where T : ILogicComponent;
        IReadOnlyCollection<ILogicComponent> GetAllComponents();
    }
}