using System.Collections.Generic;
using Core.Configs;
using Core.Models;

namespace Core.Interfaces
{
    public interface IModel
    {
        string Id { get; }

        IDictionary<string, object> Serialize(IDictionary<string, object> rawData);
        void Deserialize(IDictionary<string, object> rawData);

        T GetConfig<T>() where T : IConfig;
    }
}