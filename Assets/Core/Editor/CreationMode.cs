using System;
using System.Collections.Generic;
using Core.Configs;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public sealed class CreationMode : TrajectoryModeBase
    {
        [OnValueChanged("OnBecameVisible")]
        public bool Enabled;

        [SerializeField] 
        [PropertyOrder(0)]
        [DisableIf("_isInCreationMode")]
        [OnValueChanged("OnTransformChanged")]
        [Title("Put Root LocationTransform Here")]
        [SceneObjectsOnly]
        private Transform _rootLocationTransform;


        [ShowIfGroup("_rootLocationTransform")]
        [DisableInEditorMode]
        [SerializeField] private List<Vector3> _points;
       
        [Space]
        [SerializeField]
        [PropertyOrder(2)]
        [ShowIf("@this._points != null && this._points.Count > 0")]
        [Title("Enter Trajectory Name")]
        [SceneObjectsOnly]
        private string _trajectoryName;

        private bool _isInCreationMode;
        private Vector2 _curPosPoint;

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

        private void UpdateSceneView(SceneView sceneView)
        {
            DrawPointsOnScene(_rootLocationTransform, _points);

            if(!_isInCreationMode) return;

            Camera cam = SceneView.lastActiveSceneView.camera;
            _curPosPoint = Event.current.mousePosition;
            _curPosPoint.y = cam.pixelHeight - _curPosPoint.y;
            _curPosPoint = cam.ScreenToWorldPoint(_curPosPoint);
            _curPosPoint -= (Vector2)_rootLocationTransform.position;
            
            var e = Event.current;
            if(_isInCreationMode) 
            {
                if((e.type == EventType.MouseDown || e.type == EventType.MouseUp) && e.button == 0)
                {
                    OnTrackingEnds(false, e);
                }
            }
            else
            {
                if(e.type == EventType.Layout || e.type == EventType.Repaint) return;

                Event.current.Use();
                Event.current = null;

                ActiveEditorTracker.sharedTracker.isLocked = false;
            }
        }

        private void OnTrackingEnds(bool revert, Event e) 
        {
            e.Use();
            Event.current = null;

            if (!revert)
            {
                _points.Add(_curPosPoint);
            }
        }

        public void OnDisable()
        {
            _rootLocationTransform = null;
            ClearFields();
        }

        [PropertyOrder(3)]
        [ShowIf("@this._rootLocationTransform != null && this._points != null && this._points.Count > 0 && !string.IsNullOrEmpty(this._trajectoryName)")]
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
            var serialized = new SerializedObject(instance);
            var property = serialized.FindProperty("_points");
            for (int i = 0; i < _points.Count; i++)
            {
                property.InsertArrayElementAtIndex(i);
                serialized.ApplyModifiedProperties();
                var element = property.GetArrayElementAtIndex(i);
                element.vector3Value = _points[i];
                serialized.ApplyModifiedProperties();
            }
        }
        
        private void OnTransformChanged()
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _isInCreationMode = false;
            _trajectoryName = string.Empty;
            _curPosPoint = Vector2.zero;
            _points?.Clear();
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

        public void OnBecameInvisible()
        {
            ClearFields();        
        }
    }
}