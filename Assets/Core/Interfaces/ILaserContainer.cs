using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ILaserContainer : IContainer
    {
        void ProcessLaserShot(Vector3 componentPlayerOffset, Vector3 direction, ILaserComponent component, HitInfo info);
    }
}