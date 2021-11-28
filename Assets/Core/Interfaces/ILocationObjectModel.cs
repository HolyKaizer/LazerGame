using System;
using Core.Models;

namespace Core.Interfaces {
    public interface ILocationObjectModel : IModel
    {
        LocationObjectState CurrentState { get; }
        event Action<LocationObjectState, LocationObjectModel> ChangedState;
        event Action<LocationObjectModel> ObjectDestroyed;
    }
}