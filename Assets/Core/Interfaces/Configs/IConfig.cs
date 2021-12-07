using System.Collections.Generic;

namespace Core.Interfaces.Configs
{
    public interface IConfig
    {
        public abstract HashSet<string> GetTags();
    }
}