using System;
using Core.Interfaces.Models;

namespace Core.Interfaces.Configs
{
    public interface IHealthProcessor : ILogicProcessor
    {
        event Action<IModel> Died; 
    }
}