using System.Collections.Generic;
using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface IUserData : IModel
    {
        IDictionary<string, IModel> Models { get; }
    }
}