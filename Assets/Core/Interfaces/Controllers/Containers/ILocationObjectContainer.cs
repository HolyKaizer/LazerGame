using UnityEngine;

namespace Core.Interfaces.Controllers.Containers
{
    public interface ILocationObjectContainer : IContainer
    {
        Vector3 StartOffset { get; }
    }
}