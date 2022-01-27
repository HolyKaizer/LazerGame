using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    public abstract class BaseComponent : ScriptableObject, IModelComponent
    {
        public abstract string Id { get; }
    }
}