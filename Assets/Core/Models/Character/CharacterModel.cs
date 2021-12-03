using System.Collections.Generic;
using Core.Configs.Models;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public sealed class CharacterModel : BaseModel<CharacterConfig>, ICharacterModel
    {
        public ICharacterStorage Storage { get; private set; }
        public IMoveProcessor MoveProcessor { get; }

        public CharacterModel(string id, CharacterConfig config) : base(id, config)
        {
            MoveProcessor = ModelFactoryManager.Factory.Build<IMoveProcessor>(config.MoveType, config);
        }

        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            var modelData = new Dictionary<string, object>(1);
            modelData[Consts.Storage] = Storage.Save(modelData);
            rawData[Id] = modelData;
            return rawData;
        }

        public override void Load(IDictionary<string, object> rawData)
        {
            Storage = new CharacterStorage(rawData.TryGetNode(Consts.Storage));
        }
    }
}