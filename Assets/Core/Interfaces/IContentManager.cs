using UnityEngine;

namespace Core.Interfaces
{
    public interface IContentManager
    {
        Sprite GetSprite(string spriteAddressables);
        IBundleLoader BundleLoader { get; }
        
    }
}