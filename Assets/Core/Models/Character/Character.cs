using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models.Character 
{
    public class Character : BaseCharacterModel<ICharacterConfig>
    {
        public Character(IUserData userData, ICharacterConfig config, IDictionary<string, object> rawSave = null) : base(userData, config, rawSave)
        {
        }

        protected override IDictionary<string, object> CharacterSave(IDictionary<string, object> rawData)
        {
            return rawData;
        }

    }
}