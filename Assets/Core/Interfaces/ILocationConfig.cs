using System.Collections.Generic;

namespace Core.Interfaces {
    public interface ILocationConfig : ITypedConfig {
        IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs();
    }
}