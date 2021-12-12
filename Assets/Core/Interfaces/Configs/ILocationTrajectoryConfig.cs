using System.Collections.Generic;
using UnityEngine;

namespace Core.Interfaces.Configs 
{
    public interface ILocationTrajectoryConfig : ITypedConfig
    {
        List<Vector3> MovePoints { get; }
    }
}