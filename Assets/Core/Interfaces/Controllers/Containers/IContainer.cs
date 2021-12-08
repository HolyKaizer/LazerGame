using UnityEngine;

namespace Core.Interfaces.Controllers.Containers
{
    public interface IContainer
    {
        GameObject GameObject { get; }
        Transform Transform { get; }
    }
}