using System.Collections;
using Core.Models;

namespace Core.Interfaces
{
    public interface ISceneManager
    {
        IEnumerator LoadSceneModel(ISceneModel sceneModel);
    }
}