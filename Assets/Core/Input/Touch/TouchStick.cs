using Core.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Input.Touch
{
    public class TouchStick : MonoBehaviour
    {
        [SerializeField] private bool stickFollowsCursor = true;
        [SerializeField] private float range = 50;
        [SerializeField] private float translateSpeed = .2f;
        [ShowInInspector, ReadOnly] private RectTransform stick;
        [ShowInInspector, ReadOnly] private RectTransform background;
        
        private Vector3 startPos;
        private Vector2 lastCursorPos;

        public Vector2 Center => background.anchoredPosition;
        
        private void Start()
        {
            stick = (RectTransform) transform;
            background = (RectTransform) stick.parent.transform;
            startPos = background.anchoredPosition;
            
            if(stick.gameObject.TryGetComponent(out Image image))
            {
                var alpha = 0.0f;
#if LG_DEVELOP
                alpha = 1.0f;
#endif
                image.SetAlpha(alpha);
            }

        }

        public void ProcessPointerDown(Vector2 position)
        {
            background.anchoredPosition = position;
            stick.anchoredPosition = Vector2.zero;
        }

        public void ProcessPointerUp()
        {
            lastCursorPos = Vector2.zero;
            background.anchoredPosition = startPos;
            stick.anchoredPosition = Vector2.zero;
        }

        public void ProcessDrag(Vector2 position)
            => lastCursorPos = position;

        private void Update()
        {
            if (lastCursorPos == Vector2.zero) return;
            
            var deltaUnclamped = lastCursorPos - background.anchoredPosition;
            var delta = Vector2.ClampMagnitude(deltaUnclamped, range);
            stick.anchoredPosition = delta;

            var direction = deltaUnclamped - delta;
            if (stickFollowsCursor && direction != Vector2.zero) background.anchoredPosition += direction.normalized * translateSpeed;
        }
    }
}