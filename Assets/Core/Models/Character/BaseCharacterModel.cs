using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    internal abstract class BaseCharacterModel<TConfig> : BaseModel<TConfig>, ICharacterModel where TConfig : ICharacterConfig
    {
        protected override bool IsSerializable => true;
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
            
            CreateProcessors(components.OfType<ILogicComponent>());
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
            }

            foreach (var processor in _componentProcessors.Values)
            {
                processor.Init();   
            }
        }

        public T GetProcessor<T>(ILogicComponent component) where T : ILogicProcessor
        {
            if (_componentProcessors.TryGetValue(component, out var processor))
            {
                if (processor is T tProcessor) 
                    return tProcessor;
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Model \"{Id}\" doesnt have process \"{component.Id}\" of {typeof(T)} type");
#endif
                return default;
            }
#if LG_DEVELOP
            CustomLogger.LogAssertion($"Cannot find {typeof(T)} process at \"{Id}\" model");
#endif
            return default;
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

        protected override IDictionary<string, object> OnSave(IDictionary<string, object> rawData)
        {
            foreach (var processor in _componentProcessors.Values) 
                processor.ConsolidateData();

            IDictionary<string, object> modelData = new Dictionary<string, object> {[Consts.Storage] = Storage.Save()};
            modelData = CharacterSave(modelData);
            rawData[Id] = modelData;
            return rawData;
        }

        protected abstract IDictionary<string, object> CharacterSave(IDictionary<string, object> rawData);
    }
}