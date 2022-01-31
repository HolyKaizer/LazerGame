namespace Core.Interfaces.Configs
{
    public interface IHitProducerComponent : IModelComponent
    {
        float DamagePerHit { get; }
        float HitPeriod { get; }
        bool IsPeriodicHit { get; }
    }
}