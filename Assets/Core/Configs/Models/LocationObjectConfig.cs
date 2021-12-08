using Core.Interfaces.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models 
{
    public abstract class LocationObjectConfig : TypedConfig, ILocationObjectConfig
    {     
        public AssetReference AddressablesPrefab => _addressablePrefab;
        [SerializeField] private AssetReference _addressablePrefab;
    }
}