namespace Core.Interfaces
{
    public interface INamedConfig : IConfig
    {
        string Id { get; }
    }
}