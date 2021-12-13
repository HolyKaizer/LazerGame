using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models
{
    public static class ModelCollectionHelper
    {
        public static Dictionary<string, object> GetCollectionData<TModel>(IDictionary<string, TModel> dictionary) where  TModel : IModel
        {
            var locationObjectsData = new Dictionary<string, object>(dictionary.Count);
            foreach (var locationObject in dictionary.Values)
            {
                locationObject.Save(locationObjectsData);
            }

            return locationObjectsData;
        }

        public static void AddModelsToCollection<TModel>(IDictionary<string, TModel> collection, UserData userData, IEnumerable<ITypedConfig> locationObjectConfigs, IDictionary<string, object> rawSave) where  TModel : IModel
        {
            foreach (var config in locationObjectConfigs)
            {
                var rawData = rawSave?.TryGetNode(config.Id);
                var model = rawData?.Count > 0
                    ? ModelFactoryManager.Factory.Build<TModel>(config.Type, userData, config, rawData)
                    : ModelFactoryManager.Factory.Build<TModel>(config.Type, userData, config);
                
                collection.Add(model.Id, model);
                userData.AddModel(model);
            }
        }
    }
}