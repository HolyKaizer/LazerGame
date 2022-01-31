using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public struct HitInfo
    {
        public IModel Sender { get; }
        public IHitProducerComponent  Component { get; }

        public HitInfo(IModel sender, IHitProducerComponent component)
        {
            Sender = sender;
            Component = component;
        }
    }
}