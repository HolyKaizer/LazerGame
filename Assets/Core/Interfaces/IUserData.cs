using System;
using System.Collections.Generic;
using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface IUserData : IModel
    {
        event Action<IModel> ModelAdded;
        IDictionary<string, IModel> Models { get; }
        void AddModel(IModel model);
    }
}