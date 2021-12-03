using System.Collections.Generic;
using Core.Interfaces.Models;
using Core.Structs;

namespace Core.Interfaces {
    public interface ILocationModel : IModel
    {
        LocationState CurrentState { get; }
        IEnumerable<ILocationObjectModel> GetLocationObjects();
        IEnumerable<ICharacterModel> GetLocationCharacters();

    }
}