using UnityEngine;

namespace Core.Interfaces.Configs
{
    public interface ILaserComponent : IHitProducerComponent
    {
        float RotationSpeed { get; }
        float LaserDistance { get; }
        Vector3 PlayerOffset { get; }
    }
}