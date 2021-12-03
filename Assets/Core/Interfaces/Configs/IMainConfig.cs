using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Core.Interfaces.Configs
{
    public interface IMainConfig : IConfig
    {
        InputActionAsset ActionAsset { get; }
        TConfig GetConfig<TConfig>(string id) where TConfig : IConfig;
        IEnumerable<ITypedConfig> GetStartConfigs();
    }
}