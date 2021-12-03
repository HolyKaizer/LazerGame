using System.Collections.Generic;

namespace Core.Interfaces.Models
{
    public interface ICharacterStorage
    {
        T Get<T>(string id);
        IDictionary<string, object> Save(IDictionary<string, object> data);
    }
}