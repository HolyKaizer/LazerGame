using System.Collections.Generic;
using Core.Models;
using UnityEngine.InputSystem;

namespace Core.Configs
{
    public interface IMainConfig : IConfig
    {
        InputActionAsset ActionAsset { get; }
        TConfig GetConfig<TConfig>(string id) where TConfig : IConfig;
        IEnumerable<TypedConfig> GetStartConfigs();
    }
}