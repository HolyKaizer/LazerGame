using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Core.Interfaces.Configs
{
    public interface ISceneConfig : ITypedConfig
    {
        public IList<AssetReference> ScenesToLoad { get; }
        string LogicId { get; }
    }
}