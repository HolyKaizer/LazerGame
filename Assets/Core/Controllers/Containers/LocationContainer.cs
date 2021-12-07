using Core.Interfaces.Controllers;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class LocationContainer : BaseRootHolderContainer, ILocationContainer, IRootContainerHolder
    {
        public GameObject LocationRoot => _locationRoot;

        [SerializeField] private GameObject _locationRoot;
       
    }
}