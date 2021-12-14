using Core.Extensions;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/CharacterConfig", fileName = "CharacterConfig")]
    public sealed class CharacterConfig : BaseCharacterConfig
    {
        public override string Type => Consts.Character;
    }
}