using UnityEditor;

namespace Core.Input
{
#if UNITY_EDITOR
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
#endif
}