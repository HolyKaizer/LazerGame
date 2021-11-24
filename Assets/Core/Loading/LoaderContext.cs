using System.Collections.Generic;
using Core.Configs;
using Core.Controllers;
using Core.Models;

namespace Core.Loading
{
    internal sealed class LoaderContext : ILoaderContext
    {
        public int StepsCount { get; set; }
        public ContentManager ContentManager { get; set; }
        public IDictionary<string,string> FilePaths { get; set; }
        public JsonFileReader JsonFileReader { get; set; }
        public IDictionary<string,object> RawSaves { get; set; }
        public IMainConfig MainConfig { get; set; }
        public bool IsLoadDone { get; set; }
        public UserData UserData { get; set; }
        public EntryGameController EntryGameController { get; set; }
    }
}