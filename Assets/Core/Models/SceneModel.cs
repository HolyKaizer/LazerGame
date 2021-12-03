using System.Collections.Generic;
using Core.Configs;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Models.SceneLogic;

namespace Core.Models
{
    public sealed class SceneModel : BaseModel<ISceneConfig>, ISceneModel
    {
        public SceneModel(string id, ISceneConfig config) : base(id, config)
        {
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData) => EmptyRaw.Default;

        public override void Load(IDictionary<string, object> rawData)
        {
        }

        public void InvokeStartLogic(IMain main)
        {
            var logic = ModelFactoryManager.Factory.Build<ISceneLogic>(Config.LogicId, main);
            logic.InvokeLogic();
        }
    }
}