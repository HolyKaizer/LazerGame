namespace Core.Interfaces
{
    public interface ITypedConfig : INamedConfig
    {
        string Type { get; }
    }
}