using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Models.Character;

namespace Core.Models.Enemy 
{
    public class MovableCharacter : CharacterModel<IMovableCharacterConfig>, IMovableCharacter
    {
        public IMoveProcessor MoveProcessor { get; }

        public MovableCharacter(UserData userData, IMovableCharacterConfig config, IDictionary<string, object> rawSave = null) : base(userData, config, rawSave)
        {
            MoveProcessor = rawSave != null
                ? ModelFactoryManager.Factory.Build<IMoveProcessor>(config.MoveType, this, rawSave.TryGetNode(Consts.MoveProcessor))
                : ModelFactoryManager.Factory.Build<IMoveProcessor>(config.MoveType, this);
        }

        protected override IDictionary<string, object> OnSave(IDictionary<string, object> rawData)
        {
            rawData[Consts.MoveProcessor] = MoveProcessor.Save();
            return rawData;
        }
    }
}