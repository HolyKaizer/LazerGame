using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public class CharacterStorage : ICharacterStorage
    {
        private readonly IDictionary<string, object> _curStorage = new Dictionary<string, object>(64);
        
        public CharacterStorage(IDictionary<string, object> rawData)
        {
            foreach (var kvp in rawData)
            {
                _curStorage[kvp.Key] = kvp.Value is IBuildable buildable
                    ? buildable.BuildItem(rawData.TryGetNode(kvp.Key))
                    : kvp.Value;
            }
        }

        public T Get<T>(string id)
        {

            if(!_curStorage.TryGetValue(id, out var value))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get {id} value from storage");
#endif
                return default;
            }

            if (!(value is T tValue))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get {typeof(T)} type from {value}");
#endif
                return default;
            }
            
            return tValue;
        }

        public IDictionary<string, object> Save(IDictionary<string, object> data)
        {
            foreach (var kvp in _curStorage)
            {
                data[kvp.Key] = kvp.Value is ISave save ? save : kvp.Value;
            }

            return data;
        }
    }
}