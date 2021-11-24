using Core.Models;

namespace Core.Configs
{
    public interface INamedConfig : IConfig
    {
        string Id { get; }
    }
}