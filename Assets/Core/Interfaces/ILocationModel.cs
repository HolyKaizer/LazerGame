using System.Collections.Generic;
using Core.Interfaces.Models;
using Core.Structs;

namespace Core.Interfaces {
    public interface ILocationModel : IModel, ILoadingProcess
    {
        LocationState CurrentState { get; }
        IEnumerable<ILocationObjectModel> GetLocationObjects();
        IEnumerable<ICharacterModel> GetLocationCharacters();
    }
}