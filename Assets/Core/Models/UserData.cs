using System;
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

        public IDictionary<string, IModel> Models { get; } = new Dictionary<string, IModel>();
        
        public UserData(string id, IMainConfig config) : base(id, config)
        {
            foreach (var startConfig in config.GetStartConfigs())
            {
                Models.Add(startConfig.Id, ModelFactoryManager.Factory.Build<IModel>(startConfig.Type, this, startConfig));
            }
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            foreach (var model in Models.Values)
            {
                model.Save(rawData);
            }
            return rawData;
        }

        public override void Load(IDictionary<string, object> rawData)
        {
            foreach (var kvp in Models)
            {
                kvp.Value.Load(rawData.TryGetNode(kvp.Key));
            }
        }

        public void AddModel(IModel model)
        {
            Models[model.Id] = model;
            ModelAdded?.Invoke(model);
        }
    }
}