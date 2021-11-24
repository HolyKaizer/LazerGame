using Core.Interfaces;

namespace Core.Models
{
    public interface ISceneModel : IModel
    {
        void InvokeStartLogic(IMain main);
    }
}