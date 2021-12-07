using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface ISceneModel : IModel
    {
        void InvokeStartLogic(IMain main);
    }
}