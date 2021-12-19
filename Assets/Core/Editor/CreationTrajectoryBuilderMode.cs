using System;
using Core.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public sealed class CreationTrajectoryBuilderMode : TrajectoryEditorBuilderBase
    {
        public bool Enabled;
        
        [Space]
        [SerializeField]
        [PropertyOrder(2)]
        [ShowIf("@this._points != null && this._points.Count > 0 && !this._isInCreationMode")]
        [Title("Enter Trajectory Name")]
        [SceneObjectsOnly]
        private string _trajectoryName;
        
        [HideIf("_isInCreationMode")]
        [ShowIfGroup("_rootLocationTransform")]
        [Button("Start Creating Points", ButtonSizes.Large)]
        private void StartCreatingPoint()
        {
            _isInCreationMode = true;
            
            ActiveEditorTracker.sharedTracker.isLocked = true;
            Event.current.Use();
        } 
        
        [ShowIf("_isInCreationMode")]
        [ShowIfGroup("_rootLocationTransform")]
        [Button("Stop Creating", ButtonSizes.Large)]
        private void StopCreatingPoint()
        {
            _isInCreationMode = false;
            
            Event.current.Use();
            Event.current = null;
        }
        
        [ShowIf("_isInCreationMode")]
        [ShowIfGroup("_rootLocationTransform")]
        [Button("Clear Points", ButtonSizes.Large)]
        private void ClearPoints()
        {
            _trajectoryName = string.Empty;
            _curPosPoint = Vector2.zero;
            _points?.Clear();
        }

        public void OnGUI()
        {
            if(!Enabled) {OnBecameInvisible();}

            if(!_isInCreationMode) return;
            
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

        protected override void OnTrackingEnds(bool isCanceled, Event curEvent)
        {
            curEvent.Use();
            Event.current = null;

            if (!isCanceled)
            {
                _points.Add(_curPosPoint);
            }
        }

        [PropertyOrder(3)]
        [ShowIf("@this._rootLocationTransform != null && this._points != null && this._points.Count > 0 && !string.IsNullOrEmpty(this._trajectoryName) && !this._isInCreationMode")]
        [Button("Create Trajectory", ButtonSizes.Large)]
        private void CreateTrajectory()
        {
            var instance = ScriptableObject.CreateInstance(typeof(LocationTrajectoryConfig));
            var path = AssetDatabase.GenerateUniqueAssetPath($"Assets/Content/Configs/Trajectories/{_trajectoryName}.asset");
            AssetDatabase.CreateAsset (instance, path);
            AssetDatabase.SaveAssets ();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow ();
            Selection.activeObject = instance;
            RefreshPointsOnCurAssets(instance);
        }

        private void OnTransformChanged()
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _points?.Clear();
            _isInCreationMode = false;
            _trajectoryName = string.Empty;
            _curPosPoint = Vector2.zero;
            SceneView.duringSceneGui -= UpdateSceneView;
            if (_rootLocationTransform != null)
            {
                SceneView.duringSceneGui += UpdateSceneView;
            }
        }
        
        public void OnBecameVisible()
        {
            _rootLocationTransform = null;
            ClearFields();
        }

        public void OnDisable()
        {
            _rootLocationTransform = null;
            ClearFields();
        }
        
        public void OnBecameInvisible()
        {
            _rootLocationTransform = null;
            ClearFields();        
        }
    }
}