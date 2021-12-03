using System.Collections.Generic;
using Core.Interfaces.Configs;

namespace Core.Interfaces
{
    public interface ILoaderContext
    {
        IDictionary<string,string> FilePaths { get; }
        IContentManager ContentManager { get; }
        IJsonFileReader JsonFileReader { get; }
        IDictionary<string, object> RawSaves { get; }
        IMainConfig MainConfig { get; }
        public bool IsLoadDone { get; }
        IUserData UserData { get; }
        IController EntryGameController { get; }
        int StepsCount { get; }
    }
}