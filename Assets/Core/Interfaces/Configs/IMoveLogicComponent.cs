namespace Core.Interfaces.Configs
{
    public interface IMoveLogicComponent : ILogicComponent 
    {
        float MoveSpeed { get; }
        float RotationSpeed { get; }
    }
}