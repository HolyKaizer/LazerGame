using Core.Interfaces.Configs;
using Core.Interfaces.Systems;

namespace Core.Systems
{
    public sealed class UpdateSystem : SystemBase<IUpdatable>, IUpdatableSystem
    {
        public UpdateSystem(string id) : base(id)
        {
        }

        protected override void Update(IUpdatable item, float deltaTime)
        {
            item.Update(deltaTime);
        }
    }
}