using System;
using System.Collections;
using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models
{
    public sealed class UserData : BaseModel<IMainConfig>, IUserData
    {        
        public event Action<IModel> ModelAdded;

        private readonly IDictionary<string, IModel> _models = new Dictionary<string, IModel>();
        
        public UserData(string id, IMainConfig config) : base(id, config)
        {
            foreach (var startConfig in config.GetStartConfigs())
            {
                _models.Add(startConfig.Id, ModelFactoryManager.Factory.Build<IModel>(startConfig.Type, this, startConfig));
            }
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            foreach (var model in _models.Values)
            {
                model.Save(rawData);
            }
            return rawData;
        }

        public override void Load(IDictionary<string, object> rawData)
        {
            foreach (var kvp in _models)
            {
                kvp.Value.Load(rawData.TryGetNode(kvp.Key));
            }
        }

        public void AddModel(IModel model)
        {
            _models[model.Id] = model;
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