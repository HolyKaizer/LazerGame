using System.Collections.Generic;
using Core.Configs;
using UnityEngine.InputSystem;

namespace Core.Interfaces
{
    public interface IMainConfig : IConfig
    {
        InputActionAsset ActionAsset { get; }
        TConfig GetConfig<TConfig>(string id) where TConfig : IConfig;
        IEnumerable<TypedConfig> GetStartConfigs();
    }
}