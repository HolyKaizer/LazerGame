using UnityEngine.AddressableAssets;

namespace Core.Interfaces.Configs
{
    public interface IAddressablesPrefabConfig : INamedConfig
    {
        AssetReference AddressablesPrefab { get; }
    }
}