using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public abstract class BaseCharacterModel<TConfig> : BaseModel<TConfig>, ICharacterModel where TConfig : ICharacterConfig
    {
        private readonly IUserData _userData;
        public ICharacterStorage Storage { get; }
        
        private readonly IDictionary<ILogicComponent, ILogicProcessor> _componentProcessors;
        
        protected BaseCharacterModel(IUserData userData, TConfig config, IDictionary<string, object> rawSave = null) : base(config.Id, config)
        {
            _userData = userData;
            Storage = rawSave != null
                ? new CharacterStorage(Id, rawSave.TryGetNode(Consts.Storage))
                : new CharacterStorage(Id);
            var components = config.GetAllComponents();
            _componentProcessors = new Dictionary<ILogicComponent, ILogicProcessor>(components.Count);

            CreateProcessors(components);
        }

        private void CreateProcessors(IEnumerable<ILogicComponent> components)
        {
            foreach (var component in components)
            {
                var processor = ModelFactoryManager.Factory.Build<ILogicProcessor>(component.LogicId, this);
                _componentProcessors[component] = processor;

                if (processor.IsFixedUpdate)
                {
                    _userData.PhysicsSystem.Add(processor);
                }
                else
                {
                    _userData.UpdateSystem.Add(processor);
                }
                processor.Init();
            }
        }

        public void DestroyCharacter()
        {
            foreach (var processor in _componentProcessors.Values)
            {
                if (processor.IsFixedUpdate)
                {
                    _userData.PhysicsSystem.Remove(processor);
                }
                else
                {
                    _userData.UpdateSystem.Remove(processor);
                }
                processor.Dispose();
            }
            _componentProcessors.Clear();
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            foreach (var processor in _componentProcessors.Values) 
                processor.ConsolidateData();

            IDictionary<string, object> modelData = new Dictionary<string, object> {[Consts.Storage] = Storage.Save()};
            modelData = OnSave(modelData);
            rawData[Id] = modelData;
            return rawData;
        }

        protected abstract IDictionary<string, object> OnSave(IDictionary<string, object> rawData);
    }
}