using System.Collections.Generic;
using Core.Configs;
using Core.Controllers;
using Core.Models;

namespace Core.Loading
{
    internal interface ILoaderContext
    {
        IDictionary<string,string> FilePaths { get; }
        ContentManager ContentManager { get; }
        int StepsCount { get; }
        JsonFileReader JsonFileReader { get; }
        IDictionary<string, object> RawSaves { get; }
        MainConfig MainConfig { get; }
        public bool IsLoadDone { get; }
        UserData UserData { get; }
        EntryGameController EntryGameController { get; }
    }
}