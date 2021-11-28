using Core.Interfaces;

namespace Core.Configs {
    public abstract class TypedConfig : NamedConfig, ITypedConfig
    {
        public abstract string Type { get; }
    }
}