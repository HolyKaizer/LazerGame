using System;
using System.Collections.Generic;
using Core.Input;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    internal static class HotKeysEditorMenu
    {
        [MenuItem("ES/OpenBuildSettings &B", false, 2000)]
        private static void OpenBuildSettings()
        {
            ScriptingDefineSymbolsEditor.ShowWindow();
        }
        
        [MenuItem("ES/TrajectoryBuilderWindow &T", false, 1500)]
        private static void OpenTrajectoryBuild()
        {
            TrajectoryBuildWindow.ShowWindow();
        }
    }


    public class ScriptingDefineSymbolsEditor : EditorWindow
    {
        private readonly List<string> _defines = new List<string> {"LG_DEVELOP"};
        private readonly Dictionary<BuildTargetGroup, Dictionary<string, bool>> _states = new Dictionary<BuildTargetGroup, Dictionary<string, bool>>();
        private readonly List<TargetTab> _targets = new List<TargetTab>()
        {
            new TargetTab("Windows", BuildTargetGroup.Standalone),
            new TargetTab("iOS", BuildTargetGroup.iOS),
            new TargetTab("Android", BuildTargetGroup.Android)
        };
        private int _tab = 0;
        private string[] _tabLabels;
        private readonly Dictionary<BuildTargetGroup, string> _localDefineSymbols = new Dictionary<BuildTargetGroup, string>();
        
        public static void ShowWindow()
        {
            GetWindow(typeof(ScriptingDefineSymbolsEditor));            
        }

        private void Init()
        {
            foreach (TargetTab targetTab in _targets)
            {
                string defineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetTab.TargetPlatform);
                _localDefineSymbols.Add(targetTab.TargetPlatform, defineSymbols);
                Dictionary<string, bool> dict;
                if (!_states.TryGetValue(targetTab.TargetPlatform, out dict))
                {
                    dict = new Dictionary<string, bool>();
                    _states.Add(targetTab.TargetPlatform, dict);
                }
                foreach (string define in _defines)
                {
                    dict[define] = defineSymbols.Contains(define);
                }
            }

            _tabLabels = new string[_targets.Count];
            for (int i = 0; i < _targets.Count; i++)
            {
                TargetTab targetTab = _targets[i];
                _tabLabels.SetValue(targetTab.Label, i);
            }
        }

        private void OnGUI()
        {
            if (_states.Count == 0)
            {
                Init();
            }

            _tab = GUILayout.Toolbar(_tab, _tabLabels);

            TargetTab targetTab = _targets[_tab];
            BuildTargetGroup targetPlatform = targetTab.TargetPlatform;
            using (var verticalScope = new GUILayout.VerticalScope("box"))
            {
                DrawToggles(targetPlatform);
            }

            if (GUILayout.Button("Save"))
            {
                Save(targetPlatform);
            }
        }

        private void Save(BuildTargetGroup targetPlatform)
        {
            string localDefineSymbols = _localDefineSymbols[targetPlatform];
            foreach (string define in _defines)
            {
                Dictionary<string, bool> dict = _states[targetPlatform];
                bool state = dict[define];
                localDefineSymbols = state ? EnableDefineSymbol(define, localDefineSymbols) : DisableDefineSymbol(define, localDefineSymbols);
            }

            _localDefineSymbols[targetPlatform] = localDefineSymbols;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetPlatform, localDefineSymbols);
        }

        private void DrawToggles(BuildTargetGroup targetPlatform)
        {
            foreach (string define in _defines)
            {
                Dictionary<string, bool> dict = _states[targetPlatform];
                bool state = dict[define];
                if (GUILayout.Toggle(state, define) != state)
                {
                    _states[targetPlatform][define] = !state;                   
                }
            }
        }

        private string EnableDefineSymbol(string defineSymbol, string defineSymbols)
        {
            if (!defineSymbols.Contains(defineSymbol))
            {
                if (string.IsNullOrEmpty(defineSymbols))
                {
                    defineSymbols = defineSymbol;
                }
                else
                {
                    defineSymbols += ";" + defineSymbol;
                }
            }            
            return defineSymbols;
        }

        private string DisableDefineSymbol(string defineSymbol, string defineSymbols)
        {            
            if (defineSymbols.Contains(defineSymbol))
            {
                defineSymbols = defineSymbols.Replace(" ", string.Empty);
                int index = defineSymbols.IndexOf(defineSymbol, StringComparison.Ordinal);
                int count = defineSymbol.Length;
                if (index > 0 && defineSymbols[index - 1] == ';')
                {
                    index--;
                    count++;
                }
                defineSymbols = defineSymbols.Remove(index, count);
            }
            return defineSymbols;
        }
    }
}