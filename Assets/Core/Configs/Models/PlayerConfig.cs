using Core.Extensions;
using Core.Interfaces;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/PlayerConfig", fileName = "PlayerConfig")]
    public sealed class PlayerConfig : BaseCharacterConfig, IPlayerConfig
    {
        public override string Type => Consts.Player;
    }
}