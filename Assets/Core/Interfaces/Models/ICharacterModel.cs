using Core.Interfaces.Configs;

namespace Core.Interfaces.Models
{
    public interface ICharacterModel : IModel
    {
        public ICharacterStorage Storage { get; }
        T GetProcessor<T>(ILogicComponent component) where T : ILogicProcessor;
    }
}