namespace Core.Interfaces.Configs
{
    public interface ITrajectoryMoveLogicComponent : IMoveLogicComponent
    {
        ILocationTrajectoryConfig Trajectory { get; }
    }
}