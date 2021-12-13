using System.Collections.Generic;
using UnityEngine;

namespace Core.Interfaces.Configs 
{
    public interface ILocationTrajectoryConfig : INamedConfig
    {
        List<Vector3> MovePoints { get; }
    }
}