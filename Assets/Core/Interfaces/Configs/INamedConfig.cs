namespace Core.Interfaces.Configs
{
    public interface INamedConfig : IConfig
    {
        string Id { get; }
    }
}