using System;
using System.Collections.Generic;
using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface IUserData : IModel
    {
        event Action<IModel> ModelAdded;
        void AddModel(IModel model);
        T Get<T>(string id) where T : IModel;
        IEnumerable<IModel> GetStartModels();
    }
}