using System.Collections.Generic;

namespace Core.Interfaces.Configs
{
    public interface ISceneConfig : ITypedConfig
    {
        public IList<string> ScenesToLoad { get; }
        string LogicId { get; }
    }
}