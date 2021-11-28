using System.Collections.Generic;
using Core.Configs;
using Core.Interfaces;
using Core.Models.SceneLogic;

namespace Core.Models
{
    public sealed class SceneModel : BaseModel<ISceneConfig>, ISceneModel
    {
        public SceneModel(string id, ISceneConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Serialize(IDictionary<string, object> rawData) => EmptyRaw.Default;

        public override void Deserialize(IDictionary<string, object> rawData)
        {
        }

        public void InvokeStartLogic(IMain main)
        {
            var logic = Factory.FactoryManager.Factory.Build<ISceneLogic>(Config.LogicId, main);
            logic.InvokeLogic();
        }
    }
}