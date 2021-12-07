using UnityEngine;

namespace Core.Interfaces
{
    public interface IMoveProcessor 
    {
        public void MoveInDirection(Vector2 direction, float speed); 
        public void MoveToPoint(Vector2 point);
    }
}