using UnityEngine.AddressableAssets;

namespace Core.Interfaces.Configs
{
    public interface IAddressablesPrefabConfig : IConfig
    {
        AssetReference AddressablesPrefab { get; }
    }
}