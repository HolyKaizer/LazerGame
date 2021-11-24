using System.Collections.Generic;

namespace Core.Configs
{
    public interface ISceneConfig : ITypedConfig
    {
        public IEnumerable<string> ScenesToLoad { get; }
    }
}