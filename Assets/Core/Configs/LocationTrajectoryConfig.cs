using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs 
{
    [CreateAssetMenu(menuName = "EndlessSoftware/LocationTrajectoryConfig", fileName = "LocationTrajectoryConfig")]
    public sealed class LocationTrajectoryConfig : TypedConfig, ILocationTrajectoryConfig
    {
        public override string Type => Consts.LocationTrajectory;

        [SerializeField] private List<Vector3> _points;
    }
}