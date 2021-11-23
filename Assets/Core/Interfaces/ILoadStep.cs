using System.Collections;

namespace Core.Interfaces
{
    public interface ILoadStep
    {
        bool IsCompleted { get; }
        
        IEnumerator Load();
    }
}