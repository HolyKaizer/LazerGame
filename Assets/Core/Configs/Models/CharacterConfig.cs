using Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models
{
    public abstract class CharacterConfig : TypedConfig, ICharacterConfig
    {
        public AssetReference AddressablesPrefab => _addressablePrefab;

        public Vector3 StartPosition => _startPosition;

        [SerializeField] private AssetReference _addressablePrefab;
        [SerializeField] private Vector3 _startPosition;
    }
}