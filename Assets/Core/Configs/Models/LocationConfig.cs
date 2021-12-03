using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models 
{
    [CreateAssetMenu(menuName = "EndlessSoftware/LocationConfig", fileName = "LocationConfig")]
    public sealed class LocationConfig : TypedConfig, ILocationConfig 
    {
        [SerializeField] private LocationObjectConfig[] _locationObjectConfigs;
        [SerializeField] private CharacterConfig[] _locationCharacters;
        
        public override string Type => Consts.Location;
        public IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs() => _locationObjectConfigs;
        public IReadOnlyCollection<ICharacterConfig> GetLocationCharactersConfigs() => _locationCharacters;


        [SerializeField] private string _addressablePrefabId;
        [SerializeField] private LocationTrajectoryConfig _locationTrajectoryConfig;
        
        public string AddressablesId => _addressablePrefabId;
        public ILocationTrajectoryConfig LocationTrajectoryConfig => _locationTrajectoryConfig;
    }
}