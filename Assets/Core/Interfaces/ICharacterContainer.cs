using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterContainer : IContainer
    {
        Animator Animator { get; }
        Transform MoveTransform { get; }
    }
}