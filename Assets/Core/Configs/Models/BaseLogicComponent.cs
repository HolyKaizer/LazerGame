using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    public abstract class BaseLogicComponent : ScriptableObject, ILogicComponent
    {
        public abstract string Id { get; }
        public abstract string LogicId { get; }
    }
}