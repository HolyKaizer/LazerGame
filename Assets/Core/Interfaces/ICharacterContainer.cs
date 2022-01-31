using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterContainer : IContainer, IHitContainer
    {
        Animator Animator { get; }
        Transform MoveTransform { get; }
    }
}