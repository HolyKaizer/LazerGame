using System.Collections.Generic;
using Core.Interfaces;
using Core.Interfaces.Configs;

namespace Core.Loading
{
    public sealed class LoaderContext : ILoaderContext
    {
        public int StepsCount { get; set; }
        public IContentManager ContentManager { get; set; }
        public IDictionary<string,string> FilePaths { get; set; }
        public IJsonFileReader JsonFileReader { get; set; }
        public IDictionary<string,object> RawSaves { get; set; }
        public IMainConfig MainConfig { get; set; }
        public bool IsLoadDone { get; set; }
        public IUserData UserData { get; set; }
        public IController EntryGameController { get; set; }
    }
}