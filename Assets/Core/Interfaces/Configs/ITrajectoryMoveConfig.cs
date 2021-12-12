namespace Core.Interfaces.Configs
{
    public interface ITrajectoryMoveConfig : IMovableConfig
    {
        ILocationTrajectoryConfig Trajectory { get; }
    }
}