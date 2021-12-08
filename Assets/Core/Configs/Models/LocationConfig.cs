using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models 
{
    [CreateAssetMenu(menuName = "EndlessSoftware/LocationConfig", fileName = "LocationConfig")]
    public sealed class LocationConfig : TypedConfig, ILocationConfig 
    {
        public override string Type => Consts.Location;
        public IReadOnlyCollection<ILocationObjectConfig> GetLocationObjectConfigs() => _locationObjectConfigs;
        public IReadOnlyCollection<ICharacterConfig> GetLocationCharactersConfigs() => _locationCharacters;
        public AssetReference AddressablesPrefab => _addressablePrefab;

        public ILocationTrajectoryConfig LocationTrajectoryConfig => _locationTrajectoryConfig;

        [SerializeField] private LocationObjectConfig[] _locationObjectConfigs;
        [SerializeField] private CharacterConfig[] _locationCharacters;
        [SerializeField] private AssetReference _addressablePrefab;
        [SerializeField] private LocationTrajectoryConfig _locationTrajectoryConfig;
    }
}