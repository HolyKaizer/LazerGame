using System.Collections.Generic;
using Core.Factory;
using Core.Interfaces;
using Core.UI;

namespace Core.Models {
    public enum LocationState 
    {
        Unloaded,
        Active,
        Completed
    }

    public class LocationModel : BaseModel<ILocationConfig>, ILocationModel 
    {
        public LocationState CurrentState { get; private set; }
        private readonly IDictionary<string, ILocationObjectModel> _locationObjects;
        public LocationModel(string id, ILocationConfig config) : base(id, config)
        {
            var locationObjectConfigs = config.GetLocationObjectConfigs();
            _locationObjects = new Dictionary<string, ILocationObjectModel>(locationObjectConfigs.Count);
            foreach (var locationObjectConfig in  locationObjectConfigs)
            {
                var model = FactoryManager.Factory.Build<ILocationObjectModel>(locationObjectConfig.Type, locationObjectConfig.Id, locationObjectConfig);
                _locationObjects.Add(model.Id, model);
            }
        }
        
        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData)
        {
            var locationObjectsData = new Dictionary<string, object>(_locationObjects.Count);
            foreach (var locationObject in _locationObjects.Values)
            {
                locationObject.Serialize(locationObjectsData);
            }
            var data = new Dictionary<string, object>(1)
            {
                [Consts.CurrentState] = (int) CurrentState,
                [Consts.LocationObjects] = locationObjectsData
       
            };
            rawData.Add(Id, data);
            return rawData;
        }

        public override void Deserialize(IDictionary<string, object> rawData)
        {
            CurrentState = (LocationState) rawData.GetInt(Consts.CurrentState);
            var locationObjectsData = rawData.TryGetNode(Consts.LocationObjects);
            foreach (var objectId in locationObjectsData.Keys)
            {
                if (_locationObjects.TryGetValue(objectId, out var locationObject))
                {
                    locationObject.Deserialize(locationObjectsData.TryGetNode(objectId));
                }
            }
        }
    }
}