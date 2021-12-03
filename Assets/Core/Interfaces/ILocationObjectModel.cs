using System;
using Core.Interfaces.Models;
using Core.Structs;

namespace Core.Interfaces {
    public interface ILocationObjectModel : IModel
    {
        LocationObjectState CurrentState { get; }
        event Action<LocationObjectState, ILocationObjectModel> ChangedState;
        event Action<ILocationObjectModel> ObjectDestroyed;
    }
}