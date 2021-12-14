namespace Core.Interfaces.Systems
{
    public interface ISystem : IIdentified
    {
        void Pause(bool pause);
        void Update(float deltaTime);
        void Clear();
    }
}