using Core.Interfaces;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class CharacterContainer : BaseContainer, ICharacterContainer
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _moveTransform;

        public Animator Animator => _animator;
        public Transform MoveTransform => _moveTransform;
    }
}