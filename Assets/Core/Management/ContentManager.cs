using Core.Interfaces;
using UnityEngine;

namespace Core.Management
{
    public sealed class ContentManager : IContentManager
    {
        public IBundleLoader BundleLoader { get; }

        public ContentManager(ILoaderContext loaderContext, string startContentAddressabeles)
        {
            BundleLoader = new BundleLoader(startContentAddressabeles);
        }

        public Sprite GetSprite(string spriteAddressables)
        {
            return BundleLoader.Get<Sprite>(spriteAddressables);
        }
    }
}