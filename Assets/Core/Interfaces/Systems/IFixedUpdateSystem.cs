using Core.Interfaces.Configs;

namespace Core.Interfaces.Systems
{
    public interface IFixedUpdateSystem : ISystem
    {
        void Add(IFixedUpdate item);
        void Remove(IFixedUpdate item);
    }
}