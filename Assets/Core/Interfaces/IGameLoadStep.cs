using System.Collections;

namespace Core.Interfaces
{
    public interface IGameLoadStep
    {
        bool IsCompleted { get; }
        
        IEnumerator Load();
    }
}