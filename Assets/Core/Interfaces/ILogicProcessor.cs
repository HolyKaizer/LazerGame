using Core.Interfaces.Configs;

namespace Core.Interfaces
{
    public interface ILogicProcessor : IUpdatable, IFixedUpdate
    {
        bool IsFixedUpdate { get; }
        void Init();
        void ConsolidateData();
        void Dispose();
        void Pause();
    }
}