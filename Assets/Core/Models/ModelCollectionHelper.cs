using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models
{
    public static class ModelCollectionHelper
    {
        public static void LoadCollection<TModel>(IDictionary<string, TModel> collection, IDictionary<string, object> rawData, string id) where TModel : IModel
        {
            var data = rawData.TryGetNode(id);
            foreach (var objectId in data.Keys)
            {
                if (collection.TryGetValue(objectId, out var model))
                {
                    model.Load(data.TryGetNode(objectId));
                }
            }
        }

        public static Dictionary<string, object> GetCollectionData<TModel>(IDictionary<string, TModel> dictionary) where  TModel : IModel
        {
            var locationObjectsData = new Dictionary<string, object>(dictionary.Count);
            foreach (var locationObject in dictionary.Values)
            {
                locationObject.Save(locationObjectsData);
            }

            return locationObjectsData;
        }

        public static void AddModelsToCollection<TModel>(IDictionary<string, TModel> collection, UserData userData, IEnumerable<ITypedConfig> locationObjectConfigs) where  TModel : IModel
        {
            foreach (var config in locationObjectConfigs)
            {
                var model = ModelFactoryManager.Factory.Build<TModel>(config.Type, userData, config);
                collection.Add(model.Id, model);
                userData.AddModel(model);
            }
        }
    }
}