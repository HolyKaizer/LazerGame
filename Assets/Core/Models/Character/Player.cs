using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;

namespace Core.Models.Character
{
    internal class Player : BaseCharacterModel<IPlayerConfig>
    {
        public Player(IUserData userData, IPlayerConfig config, IDictionary<string, object> rawSave = null) : base(userData, config, rawSave)
        {
            Storage.Set(Consts.LaserRotation, new SerializableVector3());
        }

        protected override IDictionary<string, object> CharacterSave(IDictionary<string, object> rawData)
        {
            return rawData;
        }
    }
}