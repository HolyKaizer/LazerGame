using Core.Interfaces.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models 
{
    public abstract class LocationObjectConfig : TypedConfig, ILocationObjectConfig
    {
        public AssetReference AddressablesPrefab => _addressablePrefab;
        public Vector3 StartOffset => _startOffset;
        [SerializeField] private AssetReference _addressablePrefab;
        [SerializeField] private Vector3 _startOffset;
    }
}