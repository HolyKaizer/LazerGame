using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using Core.Models.Character;

namespace Core.Models.Enemy 
{
    public class EnemyModel : BaseModel<IEnemyConfig>, ICharacterModel, IMovableModel
    {
        public ICharacterStorage Storage { get; }
        public IMoveProcessor MoveProcessor { get; }
        
        public EnemyModel(string id, IEnemyConfig config) : base(id, config)
        {
            Storage = new CharacterStorage(Id);
            MoveProcessor = ModelFactoryManager.Factory.Build<IMoveProcessor>(config.MoveType, this);
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
            Storage.Load(rawData.TryGetNode(Consts.Storage));
        }
        
        
        
    }
}