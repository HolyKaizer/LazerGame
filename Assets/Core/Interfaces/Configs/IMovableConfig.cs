namespace Core.Interfaces.Configs 
{
    public interface IMovableConfig : IConfig
    {
        float MoveSpeed { get; }
        float RotationSpeed { get; }
    }
}