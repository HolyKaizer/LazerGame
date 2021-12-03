using Core.Extensions;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/PlayerConfig", fileName = "PlayerConfig")]
    public sealed class PlayerConfig : TypedConfig {
        public override string Type => Consts.Player;
    }
}