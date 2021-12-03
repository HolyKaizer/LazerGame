using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

namespace Core.Input.Touch
{
    public class ReleaseControl : OnScreenControl
    {
        [field: InputControl(layout = "Vector2"), SerializeField]
        protected override string controlPathInternal { get; set; }

        public void Signal(Vector2 value)
        {
            if (!string.IsNullOrEmpty(controlPathInternal))
                SendValueToControl(value);
        }
    }
}