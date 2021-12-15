using System;
using System.Collections.Generic;
using Core.Configs;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    public class TrajectoryBuildWindow : OdinEditorWindow
    {
        [Space]
        [PropertyOrder(0)]
        [DisableIf("_isInEditMode")]
        [Title("Put Root LocationTransform Here")]
        [SceneObjectsOnly]
        public Transform RootLocationTransform;

        [ShowIfGroup("RootLocationTransform")]
        [DisableInEditorMode]
        [SerializeField] private List<Vector3> _points;
       
        [Space]
        [PropertyOrder(2)]
        [ShowIf("@this._points != null && this._points.Count > 0")]
        [Title("Enter Trajectory Name")]
        [SceneObjectsOnly]
        public string TrajectoryName;
        private bool _isInEditMode;
        private Vector2 _curPosPoint;

        public static void ShowWindow()
        {
            GetWindow(typeof(TrajectoryBuildWindow));            
        }
        
        private void OnBecameVisible()
        {
            RootLocationTransform = null;
            _isInEditMode = false;
            TrajectoryName = string.Empty;
            _curPosPoint = Vector2.zero;
            _points?.Clear();
            SceneView.duringSceneGui += UpdateSceneView;
        }

        [HideIf("_isInEditMode")]
        [ShowIfGroup("RootLocationTransform")]
        [Button("Start Creating Points", ButtonSizes.Large)]
        private void StartCreatingPoint()
        {
            _isInEditMode = true;
            
            ActiveEditorTracker.sharedTracker.isLocked = true;
            Event.current.Use();
        } 
        
        [ShowIf("_isInEditMode")]
        [ShowIfGroup("RootLocationTransform")]
        [Button("Stop Creating", ButtonSizes.Large)]
        private void StopCreatingPoint()
        {
            _isInEditMode = false;
            
            Event.current.Use();
            Event.current = null;
        }

        protected override void OnGUI()
        {
            base.OnGUI();
            
            if(!_isInEditMode) return;
            
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
            DrawPointsOnScene();

            if(!_isInEditMode) return;

            Camera cam = SceneView.lastActiveSceneView.camera;
            _curPosPoint = Event.current.mousePosition;
            _curPosPoint.y = Screen.height - _curPosPoint.y - 70;
            _curPosPoint = cam.ScreenToWorldPoint(_curPosPoint);
            _curPosPoint -= (Vector2)RootLocationTransform.position;
            
            var e = Event.current;
            if(_isInEditMode) 
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

        private void DrawPointsOnScene()
        {
            if(_points == null || _points.Count == 0) return;
            
            var index = 0;

            foreach (var point in _points)
            {
                var curPoint = RootLocationTransform.TransformPoint(point);
                if (index == 0) { }
                else
                {
                    var prevPoint = RootLocationTransform.TransformPoint(_points[index - 1]);

                    Handles.color = Color.blue;
                    Handles.DrawSolidDisc(curPoint, RootLocationTransform.forward, 0.1f);
                    Handles.DrawSolidDisc(prevPoint, Vector3.forward, 0.1f);
                    Handles.color = Color.red;
                    Handles.DrawLine(curPoint, prevPoint, 3);
                }
                index++;
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
            
            StopCreatingPoint();
        }

        private void OnDisable()
        {
            SceneView.duringSceneGui -= UpdateSceneView;
        }

        [PropertyOrder(3)]
        [ShowIf("@this.RootLocationTransform != null && this._points != null && this._points.Count > 0 && !string.IsNullOrEmpty(this.TrajectoryName)")]
        [Button("Create Trajectory", ButtonSizes.Large)]
        private void CreateTrajectory()
        {
            var instance = CreateInstance(typeof(LocationTrajectoryConfig));
            var path = AssetDatabase.GenerateUniqueAssetPath($"Assets/Content/Configs/Trajectories/{TrajectoryName}.asset");
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
    }
}