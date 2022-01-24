using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Sirenix.OdinInspector;
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

        [Title("Put Location Objects here")]
        [SerializeField] private LocationObjectConfig[] _locationObjectConfigs;
        [Title("Put Characters here")]
        [SerializeField] private BaseCharacterConfig[] _locationCharacters;
        [Title("Location Prefab")]
        [SerializeField] private AssetReference _addressablePrefab;
    }
}