using System.Collections.Generic;
using Core.Configs;
using UnityEngine;

namespace Core.Interfaces 
{
    [CreateAssetMenu(menuName = "EndlessSoftware/LocationConfig", fileName = "LocationConfig")]
    public sealed class LocationConfig : TypedConfig, ILocationConfig 
    {
        [SerializeField] private LocationObjectConfig[] _locationObjectConfigs;
        
        public override string Type => Consts.Location;
        public IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs() => _locationObjectConfigs;

        [SerializeField] private string _addressablePrefabId;
        [SerializeField] private LocationTrajectoryConfig _locationTrajectoryConfig;
        
        public string AddressablePrefabId => _addressablePrefabId;
        public ILocationTrajectoryConfig LocationTrajectoryConfig => _locationTrajectoryConfig;
    }
}