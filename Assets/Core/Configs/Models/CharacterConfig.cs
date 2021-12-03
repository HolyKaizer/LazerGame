using Core.Extensions;
using Core.Interfaces;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/CharacterConfig", fileName = "CharacterConfig")]
    public sealed class CharacterConfig : TypedConfig, ICharacterConfig
    {
        [SerializeField] private string _moveType;
        [SerializeField] private string _addressablesId;

        public void set()
        {
            
        }
        public override string Type => Consts.Character;
        public string MoveType => _moveType;
        public string AddressablesId => _addressablesId;
    }
}