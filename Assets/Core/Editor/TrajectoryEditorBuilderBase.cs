using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public abstract class TrajectoryEditorBuilderBase
    {
        [SerializeField] 
        [PropertyOrder(0)]
        [DisableIf("_isInCreationMode")]
        [OnValueChanged("OnTransformChanged")]
        [Title("Put Root LocationTransform Here")]
        [SceneObjectsOnly]
        protected Transform _rootLocationTransform;

        protected List<Vector3> _points = new List<Vector3>();
        protected bool _isInCreationMode;
        protected Vector2 _curPosPoint;

        protected void DrawPointsOnScene(Transform rootLocationTransform, IList<Vector3> points)
        {
            if(points == null || points.Count == 0 || rootLocationTransform == null) return;
            
            var index = 0;

            foreach (var point in points)
            {
                var curPoint = rootLocationTransform.TransformPoint(point);
                if (index == 0) { }
                else
                {
                    var prevPoint = rootLocationTransform.TransformPoint(points[index - 1]);

                    Handles.color = Color.blue;
                    Handles.DrawSolidDisc(curPoint, rootLocationTransform.forward, 0.1f);
                    Handles.DrawSolidDisc(prevPoint, Vector3.forward, 0.1f);
                    Handles.color = Color.red;
                    Handles.DrawLine(curPoint, prevPoint, 3);
                }
                index++;
            }
        }
        
        protected void UpdateSceneView(SceneView sceneView)
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

        protected abstract void OnTrackingEnds(bool isCanceled, Event curEvent);

        protected void RefreshPointsOnCurAssets(ScriptableObject instance)
        {
            var serialized = new SerializedObject(instance);
            var property = serialized.FindProperty("_points");
            property.ClearArray();
            var pointsCount = _points.Count;
            for (int i = 0; i < pointsCount; i++)
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