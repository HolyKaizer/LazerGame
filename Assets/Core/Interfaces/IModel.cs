using System.Collections.Generic;
using Core.Configs;

namespace Core.Interfaces
{
    public interface IModel
    {
        IDictionary<string, object> Serialize(IDictionary<string, object> rawData);
        void Deserialize(IDictionary<string, object> rawData);

        T GetConfig<T>() where T : TypedConfig;
    }
}