using Core.Interfaces;
using UnityEngine;

namespace Core.Controllers
{
    public sealed class LocationContainer : MonoBehaviour, ILocationContainer
    {
        [SerializeField] private GameObject _locationRoot;
        public GameObject LocationRoot => _locationRoot;
        
    }
}