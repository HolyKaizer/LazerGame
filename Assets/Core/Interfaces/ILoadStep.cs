using System.Collections;

namespace Core.Interfaces
{
    public interface ILoadStep
    {
        IEnumerator Load();
    }
}