using System.Collections;

namespace Core.Interfaces
{
    public interface ILoadSceneManager
    {
        IEnumerator LoadSceneModel(ISceneModel sceneModel);
    }
}