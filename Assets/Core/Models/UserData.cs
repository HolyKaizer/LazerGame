using System.Collections.Generic;
using Core.Configs;
using Core.Factory;
using Core.Interfaces;
using Core.UI;

namespace Core.Models
{
    public sealed class UserData : BaseModel<IMainConfig>
    {
        public readonly IDictionary<string, IModel> Models = new Dictionary<string, IModel>();
        
        public UserData(string id, IMainConfig config) : base(id, config)
        {
            foreach (var startConfig in config.GetStartConfigs())
            {
                Models.Add(startConfig.Id, FactoryManager.Factory.Build<IModel>(startConfig.Type, startConfig.Id, startConfig));
            }
        }

        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData)
        {
            foreach (var model in Models.Values)
            {
                model.Serialize(rawData);
            }
            return rawData;
        }

        public override void Deserialize(IDictionary<string, object> rawData)
        {
            foreach (var kvp in Models)
            {
                kvp.Value.Deserialize(rawData.TryGetNode(kvp.Key));
            }
        }
    }
}