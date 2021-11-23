using System.Collections.Generic;
using Core.Configs;

namespace Core.Models
{
    public sealed class SceneModel : BaseModel<SceneConfig>
    {
        public SceneModel(string id, SceneConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData) => EmptyRaw.Default;

        public override void Deserialize(IDictionary<string, object> rawData)
        {
        }
    }
}