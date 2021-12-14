using System.Collections.Generic;

namespace Core.Interfaces.Configs
{
    public interface IConfig
    { 
        HashSet<string> GetTags();
    }
}