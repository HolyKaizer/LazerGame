
namespace Core.Systems
{
    public abstract class RateSystem<T> : SystemBase<T>
    {
        private readonly float _rate;

        private double _elapsedTime;

        protected RateSystem(string id, float rate) : base(id)
        {
            _rate = 1.0f / rate;
        }

        public override void Update(float deltaTime)
        {
            if(_elapsedTime >= _rate)
            {
                base.Update(_rate);
                _elapsedTime -= _rate;
            }
            _elapsedTime += deltaTime;
        }
    }
}