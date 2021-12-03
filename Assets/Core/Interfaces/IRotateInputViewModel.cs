using System;
using UnityEngine;

namespace Core.Interfaces
{
    public interface IRotateInputViewModel
    {
        event Action<Vector2> RotateChanged;
        event Action RotateEnded;
        event Action RotateStarted;
        void CallRotateChanged(Vector2 moveVector);
        void CallRotateEnded();
        void CallRotateStarted();
    }
}