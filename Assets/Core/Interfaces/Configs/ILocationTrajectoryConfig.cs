using System.Collections.Generic;
using UnityEngine;

namespace Core.Interfaces.Configs 
{
    public interface ILocationTrajectoryConfig 
    {
        List<Vector3> MovePoints { get; }
    }
}