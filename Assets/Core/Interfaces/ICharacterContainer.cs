using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterContainer
    {
        Animator Animator { get; }
        Transform MoveTransform { get; }
    }
}