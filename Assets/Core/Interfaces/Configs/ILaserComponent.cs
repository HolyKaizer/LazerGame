using UnityEngine;

namespace Core.Interfaces.Configs
{
    public interface ILaserComponent : IModelComponent
    {
        float RotationSpeed { get; }
        float LaserDistance { get; }
        Vector3 PlayerOffset { get; }
    }
}