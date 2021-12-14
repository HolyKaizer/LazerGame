using System.Collections.Generic;
using Core.Interfaces;
using Core.Interfaces.Systems;

namespace Core
{
    public sealed class Engine : IEngine
    {
        public bool InPause { get; set; }

        private readonly IDictionary<string, ISystem> _systems = new Dictionary<string, ISystem>();
        private readonly IList<ISystem> _systemsUpdate = new List<ISystem>();
        private readonly IList<ISystem> _removedSystems = new List<ISystem>();
        private bool _isUpdate;

        public void Add(ISystem system)
        {
            _systems.Add(system.Id, system);
            _systemsUpdate.Add(system);
        }

        public void Remove(ISystem system)
        {
            if (InPause || !_isUpdate)
            {
                _systems.Remove(system.Id);
                _systemsUpdate.Remove(system);
            }
            else
            {
                _removedSystems.Add(system);
            }
        }
        
        public void Update(float deltaTime)
        {
            if (InPause) return;
            _isUpdate = true;

            for (var index = 0; index < _systemsUpdate.Count; index++)
            {
                _systemsUpdate[index].Update(deltaTime);
            }
            for (var index = 0; index < _removedSystems.Count; index++)
            {
                var system = _removedSystems[index];
                _systems.Remove(system.Id);
                _systemsUpdate.Remove(system);
            }
            _removedSystems.Clear();
            _isUpdate = false;
        }

        public ISystem GetSystem(string id)
        {
            return _systems[id];
        }

        public T GetSystem<T>(string id) where T : ISystem
        {
            return (T) _systems[id];
        }
    }
}