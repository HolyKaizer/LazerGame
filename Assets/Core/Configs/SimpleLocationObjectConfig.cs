using UnityEngine;

namespace Core.Configs {
    [CreateAssetMenu(menuName = "EndlessSoftware/SimpleLocationObject", fileName = "SimpleLocationObject")]
    public sealed class SimpleLocationObjectConfig : LocationObjectConfig {
        public override string Type => Consts.Simple;
    }
}