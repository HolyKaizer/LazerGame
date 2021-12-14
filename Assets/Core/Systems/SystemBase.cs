using System.Collections.Generic;
using Core.Interfaces.Systems;

namespace Core.Systems
{
    public abstract class SystemBase<T> : ISystem
    {
        private bool _paused;

        protected readonly List<T> _items = new List<T>();
        protected readonly List<T> _removed = new List<T>();
        protected readonly HashSet<T> _removedHash = new HashSet<T>();

        protected SystemBase(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public void Add(T item)
        {
            _items.Add(item);
            OnItemAdded(item);
        }

        protected virtual void OnItemAdded(T item)
        {
           
        }

        public void Remove(T item)
        {
            _removed.Add(item);
            _removedHash.Add(item);
        }

        public void Pause(bool pause)
        {
            _paused = pause;
        }

        public virtual void Update(float deltaTime)
        {
            if (_paused) return;

            for (var index = 0; index < _items.Count; index++)
            {
                var item = _items[index];
                if (!_removedHash.Contains(item))
                {
                    Update(item, deltaTime);
                }
            }
            for (var index = 0; index < _removed.Count; index++)
            {
                var removedItem = _removed[index];
                _items.Remove(removedItem);
                ItemRemoved(removedItem);
            }
            _removedHash.Clear();
            _removed.Clear();
        }

        protected virtual void ItemRemoved(T item)
        {
        }

        protected abstract void Update(T item, float deltaTime);
        
        public void Clear()
        {
            for (var index = 0; index < _items.Count; index++)
            {
                var item = _items[index];
                Remove(item);
            }
        }
    }
}
