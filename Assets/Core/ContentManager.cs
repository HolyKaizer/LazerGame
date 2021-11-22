using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace Core
{
    internal sealed class ContentManager
    {
        public event Action<int> SpriteLoaded; 
        
        private readonly IDictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

        private int _currentNumberOfLoadedSprites;
        
        public IEnumerator LoadAtlas(string atlasName)
        {
            var operationHandle = Addressables.LoadAssetAsync<SpriteAtlas>($"{atlasName}");

            yield return operationHandle;

            var atlas = operationHandle.Result;
            _currentNumberOfLoadedSprites++;

            var sprites = new Sprite[atlas.spriteCount];
            atlas.GetSprites(sprites);
            foreach (var sprite in sprites)
            {
                _sprites[sprite.name] = sprite;
            }
            
            SpriteLoaded?.Invoke(_currentNumberOfLoadedSprites);
        }

        public Sprite GetSprite(string spriteName)
        {
            if (!_sprites.TryGetValue(spriteName, out var sprite))
            {
                Debug.LogAssertion($"Sprite Named {spriteName} doesn't load via atlass");
            }

            return sprite;
        }
    }
}