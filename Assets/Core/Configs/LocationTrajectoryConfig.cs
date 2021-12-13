using System.Collections.Generic;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs 
{
    [CreateAssetMenu(menuName = "EndlessSoftware/LocationTrajectoryConfig", fileName = "LocationTrajectoryConfig")]
    public sealed class LocationTrajectoryConfig : NamedConfig, ILocationTrajectoryConfig
    {
        [SerializeField] private List<Vector3> _points;
        public List<Vector3> MovePoints => _points;
    }
}