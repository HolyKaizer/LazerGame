using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface IPlayerModel : IModel
    {
        public ICharacterModel Character { get; }
    }
}