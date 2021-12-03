namespace Core.Interfaces.Configs
{
    public interface ITypedConfig : INamedConfig
    {
        string Type { get; }
    }
}