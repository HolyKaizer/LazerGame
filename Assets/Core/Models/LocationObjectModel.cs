using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.UI;


namespace Core.Models 
{
    public enum LocationObjectState 
    {
        Destroyed,
        Damaged,
        Common
    }

    public abstract class LocationObjectModel : BaseModel<ILocationObjectConfig>, ILocationObjectModel 
    {
        public LocationObjectState CurrentState { get; private set; }
        public event Action<LocationObjectState, LocationObjectModel> ChangedState;
        public event Action<LocationObjectModel> ObjectDestroyed;

        protected LocationObjectModel(string id, ILocationObjectConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData)
        {
            var data = new Dictionary<string, object>(1)
            {
                [Consts.CurrentState] = (int) CurrentState
            };
            rawData.Add(Id, data);
            return rawData;
        }

        public override void Deserialize(IDictionary<string, object> rawData)
        {
            CurrentState = (LocationObjectState) rawData.GetInt(Consts.CurrentState);
        }
    }
}

