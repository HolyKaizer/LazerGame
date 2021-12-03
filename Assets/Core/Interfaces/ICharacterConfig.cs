using Core.Interfaces.Configs;

namespace Core.Interfaces
{
    public interface ICharacterConfig : ITypedConfig, IAddressablesPrefabConfig
    {
        string MoveType { get; }
    }
}