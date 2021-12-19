using System;
using System.Collections.Generic;
using Core.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public sealed class EditingTrajectoryBuilderMode : TrajectoryEditorBuilderBase
    {
        public bool Enabled;
        
        [Space]
        [SerializeField]        
        [ShowIfGroup("_rootLocationTransform")]
        [OnValueChanged("OnConfigChanged")]
        private LocationTrajectoryConfig _trajectoryConfig;

        [HideIf("_isInCreationMode")]
        [ShowIf("@!this._isInCreationMode && this._rootLocationTransform != null")]
        [Button("Start Editing", ButtonSizes.Large)]
        private void StartEditing()
        {
            _isInCreationMode = true;
            
            ActiveEditorTracker.sharedTracker.isLocked = true;
            Event.current.Use();
            
        } 
        
        [ShowIf("_isInCreationMode")]
        [ShowIf("@this._isInCreationMode && this._rootLocationTransform != null")]
        [Button("Stop Editing", ButtonSizes.Large)]
        private void StopEditing()
        {
            _isInCreationMode = false;
            
            Event.current.Use();
            Event.current = null;
        }
        
        [ShowIf("@this._rootLocationTransform != null && this._points.Count != 0 && !this._isInCreationMode")]
        [Button("SaveConfig", ButtonSizes.Large)]
        private void SaveConfig()
        {
            Selection.activeObject = _trajectoryConfig;
            RefreshPointsOnCurAssets(_trajectoryConfig);
        }

        public void OnGUI()
        {
            if(!Enabled) {OnBecameInvisible();}

            if(_trajectoryConfig == null || !_isInCreationMode) return;
            
            var e = Event.current;
            
            var mouseUpDown = (e.type == EventType.MouseUp || e.type == EventType.MouseDown) && e.button == 0;
            if(mouseUpDown) 
            {
                OnTrackingEnds(false, e);
            }
            else if(e.type == EventType.KeyUp && e.keyCode == KeyCode.Escape) 
            {
                OnTrackingEnds(true, e);
            }
        }

        private void OnConfigChanged()
        {
            if (_rootLocationTransform == null || _trajectoryConfig == null)
            {
                ClearFields();
                return;
            }

            _points = new List<Vector3>(_trajectoryConfig.MovePoints);
        }

        protected override void OnTrackingEnds(bool isCanceled, Event curEvent)
        {
            curEvent.Use();
            Event.current = null;

            if (!isCanceled)
            {
                _points.Add(_curPosPoint);
            }
        }

        private void OnEnabledChanged()
        {
            _rootLocationTransform = null;
            _trajectoryConfig = null;
            ClearFields();
        } 
        
        private void OnTransformChanged()
        {
            ClearFields();
        }
        
        private void ClearFields()
        {
            _isInCreationMode = false;
            _curPosPoint = Vector2.zero;
            _points?.Clear();
            SceneView.duringSceneGui -= UpdateSceneView;
            if (_rootLocationTransform != null)
            {
                SceneView.duringSceneGui += UpdateSceneView;
            }
        }

        public void OnDisable()
        {
            _rootLocationTransform = null;
            _trajectoryConfig = null;
            ClearFields();
            ActiveEditorTracker.sharedTracker.isLocked = false;
        }

        public void OnBecameVisible()
        {
            _rootLocationTransform = null;
            _trajectoryConfig = null;
            ClearFields();
        }

        public void OnBecameInvisible()
        {
            _rootLocationTransform = null;
            _trajectoryConfig = null;
            ClearFields();        
            ActiveEditorTracker.sharedTracker.isLocked = false;
        }
    }
}