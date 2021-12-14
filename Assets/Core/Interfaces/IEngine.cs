using Core.Interfaces.Systems;

namespace Core.Interfaces
{
    public interface IEngine
    {
        void Add(ISystem system);
        void Remove(ISystem system);

        bool InPause { get; set; }
        
        void Update(float deltaTime);

        ISystem GetSystem(string id);
        T GetSystem<T>(string id) where T : ISystem;
    }
}