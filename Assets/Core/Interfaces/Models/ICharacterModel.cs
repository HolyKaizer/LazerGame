namespace Core.Interfaces.Models
{
    public interface ICharacterModel : IModel
    {
        public IMoveProcessor MoveProcessor { get; }
        public ICharacterStorage Storage { get; }
    }
}