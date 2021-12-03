using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models 
{
    public abstract class LocationObjectConfig : TypedConfig, ILocationObjectConfig
    {
        [SerializeField] private string _addressablesId;
        public string AddressablesId => _addressablesId;
    }
}