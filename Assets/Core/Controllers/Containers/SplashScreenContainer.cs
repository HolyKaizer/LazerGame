using Core.Extensions;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Controllers.Containers
{
    public sealed class SplashScreenContainer : BaseContainer, ISplashScreenContainer
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Image _fillAmountImage;

        public void SetFill(float value)
        {
            var aspectValue = Mathf.Min(1, Mathf.Max(0, value));
            _fillAmountImage.fillAmount = aspectValue;
        }

        public void SetActive(bool value)
        {
            _root.SetSafeActive(value);
        }
    }
}