using Core.Interfaces.Configs;
using Core.Interfaces.Systems;
using UnityEngine;

namespace Core.Systems
{
    public sealed class FixedUpdateSystem : RateSystem<IFixedUpdate>, IFixedUpdateSystem
    {
        public FixedUpdateSystem(string id) : base(id, 1.0f/Time.fixedDeltaTime)
        {
        }

        protected override void Update(IFixedUpdate item, float deltaTime)
        {
            item.FixedUpdate(deltaTime);
        }
    }
}