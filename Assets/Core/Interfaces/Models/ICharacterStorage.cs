using System.Collections.Generic;

namespace Core.Interfaces.Models
{
    public interface ICharacterStorage
    {
        T Get<T>(string id);
        void Set<T>(string id, T value);
        IDictionary<string, object> Save();
        T GetOrCreate<T>(string id, params object[] args);
    }
}