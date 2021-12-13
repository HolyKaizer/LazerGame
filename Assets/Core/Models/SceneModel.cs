using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;

namespace Core.Models
{
    public sealed class SceneModel : BaseModel<ISceneConfig>, ISceneModel
    {
        public SceneModel(UserData userData, ISceneConfig config) : base(config.Id, config)
        {
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData) => EmptyRaw.Default;

        public void InvokeStartLogic(IMain main)
        {
            var logic = ModelFactoryManager.Factory.Build<ISceneLogic>(Config.LogicId, main);
            logic.InvokeLogic();
        }
    }
}