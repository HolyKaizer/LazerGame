namespace Core.Interfaces.Configs
{
    public interface IMovableCharacterConfig : ICharacterConfig, ITrajectoryMoveConfig
    {
        string MoveType { get; }
    }
}