using Core.Interfaces.Configs;

namespace Core.Interfaces.Systems
{
    public interface IUpdatableSystem : ISystem
    {
        void Add(IUpdatable item);
        void Remove(IUpdatable item);
    }
}