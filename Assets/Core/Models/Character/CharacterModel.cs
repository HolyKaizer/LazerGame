using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public abstract class CharacterModel<TConfig> : BaseModel<TConfig>, ICharacterModel where TConfig : ICharacterConfig
    {
        public ICharacterStorage Storage { get; }

        protected CharacterModel(UserData userData, TConfig config, IDictionary<string, object> rawSave = null) : base(config.Id, config)
        {
            Storage = rawSave != null
                ? new CharacterStorage(Id, rawSave.TryGetNode(Consts.Storage))
                : new CharacterStorage(Id);
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            IDictionary<string, object> modelData = new Dictionary<string, object> {[Consts.Storage] = Storage.Save()};
            modelData = OnSave(modelData);
            rawData[Id] = modelData;
            return rawData;
        }

        protected abstract IDictionary<string, object> OnSave(IDictionary<string, object> rawData);
    }
}