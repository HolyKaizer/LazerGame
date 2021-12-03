using Core.Interfaces;
using UnityEngine;

namespace Core.Management
{
    public sealed class MainSceneContainer : MonoBehaviour, IMainSceneContainer
    {
        [SerializeField] private GameObject _locationRoot;
        [SerializeField] private GameObject _uiRoot;
        [SerializeField] private RectTransform _uiRectTransform;

        public GameObject LocationRoot => _locationRoot;
        public GameObject UiRoot => _uiRoot;
        public RectTransform UiRectTransform => _uiRectTransform;
    }
}