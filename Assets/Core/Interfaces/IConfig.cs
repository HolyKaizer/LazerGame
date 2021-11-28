using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IConfig
    {
        public abstract IEnumerable<string> GetTags();
    }
}