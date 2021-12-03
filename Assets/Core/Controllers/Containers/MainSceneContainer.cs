using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Controllers.Containers
{
    public sealed class MainSceneContainer : BaseRootHolderContainer, IMainSceneContainer
    {
        [SerializeField] private GameObject _locationRoot;
        [SerializeField] private GameObject _uiRoot;
        [SerializeField] private RectTransform _uiRectTransform;

        public Transform LocationRoot => _locationRoot.transform;
        public GameObject UiRoot => _uiRoot;
        public RectTransform UiRectTransform => _uiRectTransform;
    }
}