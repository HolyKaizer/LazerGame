using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public delegate void HitHandler(IModel model, float prevValue, float curValue);
    public interface IHitHandlerProcessor : ILogicProcessor
    {
        event HitHandler Hit;
        void ProcessHit(HitInfo info);
    }
}