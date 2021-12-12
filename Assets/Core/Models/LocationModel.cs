using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;
using Core.Structs;

namespace Core.Models {
    public class LocationModel : BaseModel<ILocationConfig>, ILocationModel 
    {
        public LocationState CurrentState { get; private set; }
        public bool IsLoadingCompleted { get; private set;}
        public float CurLoadingProgress { get; private set; }

        private readonly IDictionary<string, ILocationObjectModel> _locationObjects;
        private readonly IDictionary<string, ICharacterModel> _locationCharacters;

        public LocationModel(UserData userData, ILocationConfig config) : base(config.Id, config)
        {
            var locationObjectConfigs = config.GetLocationObjectConfigs();
            _locationObjects = new Dictionary<string, ILocationObjectModel>(locationObjectConfigs.Count);
            var charactersConfigs = config.GetLocationCharactersConfigs();
            _locationCharacters = new Dictionary<string, ICharacterModel>(charactersConfigs.Count);

            ModelCollectionHelper.AddModelsToCollection(_locationObjects, userData, locationObjectConfigs);
            ModelCollectionHelper.AddModelsToCollection(_locationCharacters, userData, charactersConfigs);
        }

        public IEnumerable<ILocationObjectModel> GetLocationObjects()
        {
            return _locationObjects.Values;
        }
        
        public IEnumerable<ICharacterModel> GetLocationCharacters()
        {
            return _locationCharacters.Values;
        }

        public void SetLoadingComplete()
        {
            IsLoadingCompleted = true;
        }
        
        public void SetLoadingProgress(float value)
        {
            CurLoadingProgress = value;
        }
        
        public override IDictionary<string, object> Save(IDictionary<string, object> rawData)
        {
            var data = new Dictionary<string, object>(1)
            {
                [Consts.CurrentState] = (int) CurrentState,
                [Consts.LocationObjects] = ModelCollectionHelper.GetCollectionData(_locationObjects),
                [Consts.Characters] = ModelCollectionHelper.GetCollectionData(_locationCharacters)
            };
            
            rawData.Add(Id, data);
            return rawData;
        }
        
        public override void Load(IDictionary<string, object> rawData)
        {
            CurrentState = (LocationState) rawData.GetInt(Consts.CurrentState);
            ModelCollectionHelper.LoadCollection(_locationObjects, rawData, Consts.LocationObjects);
            ModelCollectionHelper.LoadCollection(_locationCharacters, rawData, Consts.Characters);
        }
    }
}