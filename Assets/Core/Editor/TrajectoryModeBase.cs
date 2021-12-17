using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [Serializable]
    public abstract class TrajectoryModeBase
    {
        protected void DrawPointsOnScene(Transform rootLocationTransform, IList<Vector3> points)
        {
            if(points == null || points.Count == 0) return;
            
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
    }
}