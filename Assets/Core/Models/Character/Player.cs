using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;

namespace Core.Models.Character
{
    public class Player : BaseCharacterModel<IPlayerConfig>
    {
        public Player(IUserData userData, IPlayerConfig config, IDictionary<string, object> rawSave = null) : base(userData, config, rawSave)
        {
            var laser = new LaserModel(Consts.Laser, config.LaserConfig);
            Storage.Set(Consts.Laser, laser);
        }

        protected override IDictionary<string, object> CharacterSave(IDictionary<string, object> rawData)
        {
            return Storage.Get<ILaserModel>(Consts.Laser).Save(rawData);
        }
    }
}