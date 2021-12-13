using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public class CharacterStorage : ICharacterStorage
    {
        private readonly string _id;
        private readonly IDictionary<string, object> _curStorage = new Dictionary<string, object>(64);
        
        public CharacterStorage(string id, IDictionary<string, object> rawSave = null)
        {
            if (rawSave != null)
            {
                Load(rawSave);
            }

            _id = id;
        }

        private void Load(IDictionary<string, object> rawSave)
        {
            foreach (var kvp in rawSave)
            {
                var value = kvp.Value;
                if (kvp.Value is IDictionary<string, object> buildNode)
                {
                    value = ModelFactoryManager.Factory.Build<IBuildable>(buildNode.GetString(Consts.Type), buildNode);
                }

                _curStorage[kvp.Key] = value;
            }
        }

        public T GetOrCreate<T>(string id, params object[] args)
        {
            if (!_curStorage.TryGetValue(id, out var value))
            {
                value = ModelFactoryManager.Factory.SimpleBuild<T>(args);
                _curStorage[id] = value;
            }

            return (T) value;
        }
        
        public void Set<T>(string id, T value)
        {
            _curStorage[id] = value;
        }
        
        public T Get<T>(string id)
        {

            if(!_curStorage.TryGetValue(id, out var value))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get nonexistent item named=\"{id}\" from {_id} storage");
#endif
                return default;
            }

            if (!(value is T tValue))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get {typeof(T)} type from {value.GetType()}");
#endif
                return default;
            }
            
            return tValue;
        }

        public IDictionary<string, object> Save()
        {
            var data = new Dictionary<string, object>(_curStorage.Count);
            foreach (var storageItemKvp in _curStorage)
            {
                data[storageItemKvp.Key] = storageItemKvp.Value is ISave save 
                    ? save.Save() 
                    : storageItemKvp.Value;
            }

            return data;
        }
    }
}