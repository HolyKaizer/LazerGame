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

        protected LocationObjectModel(string id, ILocationObjectConfig config, IDictionary<string, object> rawData = null) : base(id, config)
        {
            if (rawData != null)
            {
                CurrentState = (LocationObjectState) rawData.GetInt(Consts.CurrentState);
            }
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
    }
}

