using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models
{
    public abstract class BaseModel<TConfig> : IModel where TConfig : IConfig
    {
        protected abstract bool IsSerializable { get; }
        public string Id { get; }
        protected TConfig Config { get; }

        protected BaseModel(string id, TConfig config)
        {
            Id = id;
            Config = config;
        }

        public IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            return IsSerializable ? OnSave(rawData) : EmptyRaw.Default;
        }

        protected abstract IDictionary<string, object> OnSave(IDictionary<string, object> rawData);

        public T GetConfig<T>() where T : IConfig
        {
            if (Config is T tConfig) return tConfig;
            
            CustomLogger.LogAssertion($"Config of \"{Id}\" model doesn't derived from \"{typeof(T)}\" type");
            return default;
        }
    }
}