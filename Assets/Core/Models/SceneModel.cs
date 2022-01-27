using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;

namespace Core.Models
{
    public sealed class SceneModel : BaseModel<ISceneConfig>, ISceneModel
    {
        protected override bool IsSerializable => false;

        public SceneModel(UserData userData, ISceneConfig config) : base(config.Id, config)
        {
        }

        protected override IDictionary<string, object> OnSave(IDictionary<string, object> rawData) => EmptyRaw.Default;

        public void InvokeStartLogic(IMain main)
        {
            var logic = ModelFactoryManager.Factory.Build<ISceneLogic>(Config.LogicId, main);
            logic.InvokeLogic();
        }
    }
}