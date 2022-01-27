using Core.Interfaces.Configs;

namespace Core.Interfaces
{
    public interface IPlayerConfig : ICharacterConfig
    {
        ILaserConfig LaserConfig { get; }
    }
}