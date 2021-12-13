using Core.Interfaces.Models;

namespace Core.Interfaces.Configs
{
    public interface IMovableCharacter : ICharacterModel
    {
        public IMoveProcessor MoveProcessor { get; }
    }
}