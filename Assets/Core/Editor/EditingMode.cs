using System;
using Core.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public sealed class EditingMode : TrajectoryModeBase
    {
        [OnValueChanged("OnBecameVisible")]
        public bool Enabled;
        
        [SerializeField] 
        [PropertyOrder(0)]
        [DisableIf("_isInEditingMode")]
        [OnValueChanged("OnTransformChanged")]
        [Title("Put Root LocationTransform Here")]
        [SceneObjectsOnly]
        private Transform _rootLocationTransform;

        private bool _isInEditingMode;
        
        [Space]
        [SerializeField]
        private LocationTrajectoryConfig _trajectoryConfig;
        
        [HideIf("_isInEditingMode")]
        [ShowIfGroup("_rootLocationTransform")]
        [ShowIfGroup("_trajectoryConfig")]
        [Button("Start Editing", ButtonSizes.Large)]
        private void StartEditing()
        {
            _isInEditingMode = true;
            
            ActiveEditorTracker.sharedTracker.isLocked = true;
            Event.current.Use();
        } 
        
        [ShowIf("_isInCreationMode")]
        [ShowIfGroup("_rootLocationTransform")]
        [Button("Stop Editing", ButtonSizes.Large)]
        private void StopEditing()
        {
            _isInEditingMode = false;
            
            Event.current.Use();
            Event.current = null;
        }

        public void OnGUI()
        {
            if(_trajectoryConfig == null) return;
            
            DrawPointsOnScene(_rootLocationTransform, _trajectoryConfig.MovePoints);
        }

        private void OnEnabledChanged()
        {
            
        } 
        
        private void OnTransformChanged()
        {
            
        }
        
        private void OnTrajectoryConfigChanged()
        {
            
        }
    }
}