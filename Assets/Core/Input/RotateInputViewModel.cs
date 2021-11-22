using System;
using UnityEngine;

namespace Core.Input
{
    internal class RotateInputViewModel
    {
        public event Action<Vector2> RotateChanged;
        public event Action RotateEnded;
        public event Action RotateStarted;
        
        public void CallRotateChanged(Vector2 moveVector)
        {
            RotateChanged?.Invoke(moveVector);
        }

        public void CallRotateEnded()
        {
            RotateEnded?.Invoke();
        }

        public void CallRotateStarted()
        {
            RotateStarted?.Invoke();
        }
    }
}