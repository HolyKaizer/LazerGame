using Core.Interfaces;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class PlayerContainer : CharacterContainer, IPlayerContainer
    {
        [SerializeField] private LaserContainer _laserContainer;

        public ILaserContainer LaserContainer => _laserContainer;
    }
}