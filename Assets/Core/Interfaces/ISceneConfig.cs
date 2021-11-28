using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISceneConfig : ITypedConfig
    {
        public IList<string> ScenesToLoad { get; }
        string LogicId { get; }
    }
}