using Core.Interfaces;

namespace Core.Configs {
    public class LocationTrajectoryConfig : TypedConfig, ILocationTrajectoryConfig {
        public override string Type => Consts.LocationTrajectory;
    }
}