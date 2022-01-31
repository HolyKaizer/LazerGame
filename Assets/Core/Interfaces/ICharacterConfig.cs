using System.Collections.Generic;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        Vector3 StartPosition { get; }
        T GetComponent<T>(string id) where T : IModelComponent;
        bool TryGetComponent<T>(string id, out T component) where T : IModelComponent;
        IReadOnlyCollection<IModelComponent> GetAllComponents();
    }
}