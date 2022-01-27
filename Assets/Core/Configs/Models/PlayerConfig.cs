using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/PlayerConfig", fileName = "PlayerConfig")]
    public sealed class PlayerConfig : BaseCharacterConfig, IPlayerConfig
    {
        public override string Type => Consts.Player;
        [SerializeField] private LaserConfig _laserConfig;

        public ILaserConfig LaserConfig => _laserConfig;
    }
}