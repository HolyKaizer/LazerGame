using Core.Extensions;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/CharacterConfig", fileName = "CharacterConfig")]
    public sealed class CharacterConfig : TypedConfig 
    {
        [SerializeField] private string _moveType;
    
        public override string Type => Consts.Character;
        public string MoveType => _moveType;
    }
}