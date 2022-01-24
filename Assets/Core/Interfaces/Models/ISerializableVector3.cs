using UnityEngine;

namespace Core.Interfaces.Models
{
    public interface ISerializableVector3 
    {
        Vector3 Get();
        void Set(Vector3 position);
    }
}