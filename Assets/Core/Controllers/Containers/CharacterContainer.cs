using System;
using Core.Interfaces;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public class CharacterContainer : BaseContainer, ICharacterContainer
    {
        public event Action<HitInfo> Hit;
        public Animator Animator => _animator;
        public Transform MoveTransform => _moveTransform;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _moveTransform;

        public void HandelHit(HitInfo info)
        {
            Hit?.Invoke(info);
        }
    }
}