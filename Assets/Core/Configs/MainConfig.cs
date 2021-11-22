using UnityEngine;

namespace Core.Configs
{
    public sealed class MainConfig : TypedConfig
    {
        public override string Type => "main";
        
        public string GetConfig()
        {
            return "";
        }
    }

    public abstract class TypedConfig : ScriptableObject
    {
        public abstract string Type { get; }
    }
}