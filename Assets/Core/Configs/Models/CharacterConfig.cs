using Core.Extensions;
using Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/CharacterConfig", fileName = "CharacterConfig")]
    public sealed class CharacterConfig : TypedConfig, ICharacterConfig
    {
        public override string Type => Consts.Character;
        public AssetReference AddressablesPrefab => _addressablePrefab;
        public string MoveType => _moveType;
        
        [SerializeField] private AssetReference _addressablePrefab;
        [SerializeField] private string _moveType;
    }
}