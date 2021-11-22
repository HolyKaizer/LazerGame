using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

namespace Core.Input.Touch
{
    public class TouchControl : OnScreenControl
    {
        [field: InputControl(layout = "Button"), SerializeField]
        protected override string controlPathInternal { get; set; }

        public void Signal()
        {
            if (!string.IsNullOrEmpty(controlPathInternal))
            {
                SendValueToControl(1f);
                SendValueToControl(0f);
            }
        }
    }
}