using System.Collections;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Controllers
{
    public abstract class BaseContainerLoaderController<TContainer> : BaseController where TContainer : IContainer
    {
        protected TContainer Container { get; private set; }     
        protected bool IsContainerLoaded { get; private set; }

        protected readonly IMain _main;
        private readonly Transform _containerRoot;
        private readonly IAddressablesPrefabConfig _addressablesConfig;

        protected BaseContainerLoaderController(IMain main, Transform containerRoot, IAddressablesPrefabConfig addressablesConfig)
        {
            _main = main;
            _containerRoot = containerRoot;
            _addressablesConfig = addressablesConfig;
        }

        protected override void OnInit()
        {
            _main.MonoBehaviour.StartCoroutine(LoadContainerAsync(_addressablesConfig.AddressablesPrefab));
        }

        private IEnumerator LoadContainerAsync(AssetReference addressables)
        {
            yield return _main.LoaderContext.ContentManager.BundleLoader.GetAsync<GameObject>(addressables.AssetGUID, OnContainerPrefabLoaded);
        }

        private void OnContainerPrefabLoaded(string id, GameObject prefab)
        {
            var go = _containerRoot != null
                ? Object.Instantiate(prefab, _containerRoot, false)
                : Object.Instantiate(prefab);

            if (go.TryGetComponent<TContainer>(out var container))
            {
                Container = container;
                OnContainerLoaded();
                IsContainerLoaded = true;
            }
            else
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Controller {go.name} doesn't have {typeof(TContainer)} Container component");
#endif
            }
        }

        protected abstract void OnContainerLoaded();

        protected override void OnDispose()
        {
            _main.LoaderContext?.ContentManager?.BundleLoader?.ReleaseAsset(_addressablesConfig?.AddressablesPrefab.AssetGUID);
            Container = default;
            IsContainerLoaded = false;
        }
    }
}