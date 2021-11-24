using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models
{
    public abstract class BaseModel<TConfig> : IModel where TConfig : IConfig
    {
        public string Id { get; }
        protected TConfig Config { get; }

        protected BaseModel(string id, TConfig config)
        {
            Id = id;
            Config = config;
        }
        
        public abstract IDictionary<string, object> Serialize(IDictionary<string, object> rawData);

        public abstract void Deserialize(IDictionary<string, object> rawData);
        
        public T GetConfig<T>() where T : IConfig
        {
            if (Config is T tConfig) return tConfig;
            
            CustomLogger.LogAssertion($"Config of \"{Id}\" model doesn't derived from \"{typeof(T)}\" type");
            return default;
        }
    }
}