using System;
using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using Core.Interfaces.Systems;

namespace Core.Models
{
    public sealed class UserData : BaseModel<IMainConfig>, IUserData
    {
        public event Action<IModel> ModelAdded;
        public IUpdatableSystem UpdateSystem { get; }
        public IFixedUpdateSystem PhysicsSystem { get; }
        protected override bool IsSerializable => false;

        private readonly IDictionary<string, IModel> _models = new Dictionary<string, IModel>();

        public UserData(string id, IEngine engine, IMainConfig config, IDictionary<string, object> rawSaveData = null) : base(id, config)
        {
            UpdateSystem = engine.GetSystem<IUpdatableSystem>(Consts.LogicSystem);
            PhysicsSystem = engine.GetSystem<IFixedUpdateSystem>(Consts.PhysicsSystem);
            
            foreach (var startConfig in config.GetStartConfigs())
            {
                IModel model;
                if (rawSaveData != null)
                {
                    var rawData = rawSaveData.TryGetNode(startConfig.Id);
                    model = rawData.Count > 0 
                        ? ModelFactoryManager.Factory.Build<IModel>(startConfig.Type, this, startConfig, rawData)
                        : ModelFactoryManager.Factory.Build<IModel>(startConfig.Type, this, startConfig);
                }
                else
                {
                    model = ModelFactoryManager.Factory.Build<IModel>(startConfig.Type, this, startConfig);
                }

                AddModel(model);
            }
        }
        
        protected override IDictionary<string, object> OnSave(IDictionary<string, object> rawData)
        {
            foreach (var model in _models.Values)
            {
                model.Save(rawData);
            }
            return rawData;
        }

        private void AddModel(IModel model)
        {
            _models[model.Id] = model;
            
            if (model is IUpdatable updatable)
            {
                UpdateSystem.Add(updatable);
            }
            if (model is IFixedUpdate fixedUpdate)
            {
                PhysicsSystem.Add(fixedUpdate);
            }
            
            ModelAdded?.Invoke(model);
        }

        public T Get<T>(string id) where T : IModel
        {
            if(!_models.TryGetValue(id, out var value))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get nonexistent model named=\"{id}\" from UserData");
#endif
                return default;
            }

            if (!(value is T tValue))
            {
#if LG_DEVELOP
                CustomLogger.LogAssertion($"Try to get {typeof(T)} type from {value.GetType()} model");
#endif
                return default;
            }
            
            return tValue;
        }

        public IEnumerable<IModel> GetStartModels()
        {
            foreach (var model in _models.Values)
            {
                if (model.GetConfig<INamedConfig>().GetTags().Contains(Consts.Start))
                {
                    yield return model;
                }
            }
        }
    }
}