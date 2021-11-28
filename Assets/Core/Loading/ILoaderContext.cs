using System.Collections.Generic;
using Core.Configs;
using Core.Controllers;
using Core.Interfaces;
using Core.Models;

namespace Core.Loading
{
    public interface ILoaderContext
    {
        IDictionary<string,string> FilePaths { get; }
        ContentManager ContentManager { get; }
        JsonFileReader JsonFileReader { get; }
        IDictionary<string, object> RawSaves { get; }
        IMainConfig MainConfig { get; }
        public bool IsLoadDone { get; }
        UserData UserData { get; }
        EntryGameController EntryGameController { get; }
        int StepsCount { get; }
    }
}