using System;
using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Structs;


namespace Core.Models 
{
    public abstract class LocationObjectModel : BaseModel<ILocationObjectConfig>, ILocationObjectModel 
    {
        public LocationObjectState CurrentState { get; private set; }
        public event Action<LocationObjectState, ILocationObjectModel> ChangedState;
        public event Action<ILocationObjectModel> ObjectDestroyed;

        protected LocationObjectModel(string id, ILocationObjectConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            var data = new Dictionary<string, object>(1)
            {
                [Consts.CurrentState] = (int) CurrentState
            };
            rawData.Add(Id, data);
            return rawData;
        }

        public override void Load(IDictionary<string, object> rawData)
        {
            CurrentState = (LocationObjectState) rawData.GetInt(Consts.CurrentState);
        }
    }
}

