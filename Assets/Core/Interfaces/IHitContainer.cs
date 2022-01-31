using System;

namespace Core.Interfaces
{
    public interface IHitContainer 
    {
        event Action<HitInfo> Hit;
        void HandelHit(HitInfo producer);
    }
}