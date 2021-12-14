using System;
using System.Collections.Generic;
using Core.Interfaces.Models;
using Core.Interfaces.Systems;

namespace Core.Interfaces
{
    public interface IUserData : IModel
    {
        event Action<IModel> ModelAdded;
        T Get<T>(string id) where T : IModel;
        IEnumerable<IModel> GetStartModels();
        IUpdatableSystem UpdateSystem { get; }
        IFixedUpdateSystem PhysicsSystem { get; }
    }
}