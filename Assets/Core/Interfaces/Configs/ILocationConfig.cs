using System.Collections.Generic;

namespace Core.Interfaces.Configs {
    public interface ILocationConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs();
        IReadOnlyCollection<ICharacterConfig> GetLocationCharactersConfigs();
        ILocationTrajectoryConfig LocationTrajectoryConfig { get; }
    }
}