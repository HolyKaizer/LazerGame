using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ILaserContainer : IContainer
    {
        void DrawLineInDirection(Vector2 origin, Vector2 direction, float distance);
    }
}