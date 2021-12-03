using Core.Extensions;
using Core.Interfaces.Configs;

namespace Core.Configs {
    public class LocationTrajectoryConfig : TypedConfig, ILocationTrajectoryConfig {
        public override string Type => Consts.LocationTrajectory;
    }
}