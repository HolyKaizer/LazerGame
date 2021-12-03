using Core.Extensions;
using UnityEngine;

namespace Core.Configs.Models {
    [CreateAssetMenu(menuName = "EndlessSoftware/SimpleLocationObject", fileName = "SimpleLocationObject")]
    public sealed class SimpleLocationObjectConfig : LocationObjectConfig {
        public override string Type => Consts.Simple;
    }
}