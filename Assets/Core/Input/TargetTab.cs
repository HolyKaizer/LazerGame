using UnityEditor;

namespace Core.Input.Core.Input
{
    public class TargetTab
    {
        public string Label;
        public BuildTargetGroup TargetPlatform;

        public TargetTab(string label, BuildTargetGroup targetPlatform)
        {
            Label = label;
            TargetPlatform = targetPlatform;
        }
    }
}