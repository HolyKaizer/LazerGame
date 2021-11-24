using System.Collections.Generic;

namespace Core.Configs
{
    public interface ISceneConfig : ITypedConfig
    {
        public IList<string> ScenesToLoad { get; }
        string LogicId { get; }
    }
}