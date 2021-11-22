using System.Collections.Generic;
using Core.Configs;

namespace Core.Models
{
    public sealed class UserData : BaseModel<MainConfig>
    {
        public UserData(string id, MainConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData)
        {
            return new Dictionary<string, object>();
        }

        public override void Deserialize(IDictionary<string, object> rawData)
        {
        }
    }
}