using Core.Interfaces.Models;

namespace Core.Interfaces.Configs
{
    public interface IMovableModel : IModel
    {
        ICharacterStorage Storage { get; }
    }
}