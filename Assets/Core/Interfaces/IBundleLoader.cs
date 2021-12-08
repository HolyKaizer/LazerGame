using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Interfaces
{
    public interface IBundleLoader
    {
        IEnumerator LoadForWarmup();
        T Get<T>(string key) where T : UnityEngine.Object;
        bool IsLoaded(string key);
        Task<T> GetAsync<T>(string key, Action<string, T> completeCallback = null) where T : UnityEngine.Object;
        Task<T> GetAsync<T>(AssetReference assetReference, Action<string, T> completeCallback = null) where T : UnityEngine.Object;
        Task PreloadAsync<T>(string key, Action<string, T> completeCallback) where T : UnityEngine.Object;
        void ReleaseAsset(string key);
        T GetComponent<T>(string key) where T : Component;
        void ReleaseAndUnload();
        void Release();
    }
}