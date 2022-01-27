using Core.Interfaces.Configs;

namespace Core.Configs.Models
{
    public abstract class BaseLogicComponent : BaseComponent, ILogicComponent
    {
        public abstract string LogicId { get; }
    }
}