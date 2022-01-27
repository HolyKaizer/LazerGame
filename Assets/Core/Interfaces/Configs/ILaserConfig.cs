using UnityEngine;

namespace Core.Interfaces.Configs
{
    public interface ILaserConfig : ITypedConfig
    {
        float RotationSpeed { get; }
        float LaserDistance { get; }
        Vector3 PlayerOffset { get; }
    }
}