using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Input.Touch
{
    [RequireComponent(typeof(DragControl))]
    [RequireComponent(typeof(TouchControl))]
    [RequireComponent(typeof(ReleaseControl))]
    public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [ShowInInspector, ReadOnly] private TouchStick stick;
        [ShowInInspector, ReadOnly] private DragControl drag;
        [ShowInInspector, ReadOnly] private TouchControl touch;
        [ShowInInspector, ReadOnly] private ReleaseControl release;
        
        private RectTransform rect;
        private bool isDragged;
        private Vector2 delta;

        private void Start()
        {
            rect = (RectTransform) transform;
            stick = GetComponentInChildren<TouchStick>(true);
            drag = GetComponent<DragControl>();
            touch = GetComponent<TouchControl>();
            release = GetComponent<ReleaseControl>();
        }

        public void Update()
        {
            if (isDragged) drag.Signal(delta);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out var pointerDownPos);
            stick.ProcessPointerDown(pointerDownPos);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            stick.ProcessPointerUp();
            if (isDragged) 
                release.Signal(delta);
            else
                touch.Signal();
            drag.Signal(Vector2.zero);
        }


        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out var position);
            stick.ProcessDrag(position);
            delta = position - stick.Center;
            delta = delta.normalized;
        }

        public void OnBeginDrag(PointerEventData eventData)
            => isDragged = true;
        
        public void OnEndDrag(PointerEventData eventData)
            => isDragged = false;
    }
}