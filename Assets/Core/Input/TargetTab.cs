using UnityEditor;

namespace Core.Input
{
    public class TargetTab
    {
        public string Label { get; }
        public BuildTargetGroup TargetPlatform { get; }

        public TargetTab(string label, BuildTargetGroup targetPlatform)
        {
            Label = label;
            TargetPlatform = targetPlatform;
        }
    }
}