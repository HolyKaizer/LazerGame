namespace Core.Interfaces.Models
{
    public interface ICharacterModel : IModel
    {
        public ICharacterStorage Storage { get; }
    }
}