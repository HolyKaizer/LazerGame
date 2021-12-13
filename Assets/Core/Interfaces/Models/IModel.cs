using System.Collections.Generic;
using Core.Interfaces.Configs;

namespace Core.Interfaces.Models
{
    public interface IModel
    {
        string Id { get; }
        IDictionary<string, object> Save(IDictionary<string, object> rawData);
        T GetConfig<T>() where T : IConfig;
    }
}