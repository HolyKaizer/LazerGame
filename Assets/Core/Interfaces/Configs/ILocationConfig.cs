using System.Collections.Generic;

namespace Core.Interfaces.Configs {
    public interface ILocationConfig : ITypedConfig
    {
        IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs();
        string AddressablePrefabId { get; }
        ILocationTrajectoryConfig LocationTrajectoryConfig { get; }
    }
}