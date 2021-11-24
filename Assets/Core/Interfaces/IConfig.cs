using System.Collections.Generic;

namespace Core.Models
{
    public interface IConfig
    {
        public abstract IEnumerable<string> GetTags();
    }
}