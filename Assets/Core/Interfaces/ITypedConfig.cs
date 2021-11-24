namespace Core.Configs
{
    public interface ITypedConfig : INamedConfig
    {
        string Type { get; }
    }
}