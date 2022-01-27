namespace Core.Interfaces
{
    public interface IPlayerContainer : ICharacterContainer
    {
        ILaserContainer LaserContainer { get; }
    }
}