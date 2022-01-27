using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    internal sealed class LaserController : BaseController, IUpdatable
    {
        private readonly ILaserContainer _container;
        private readonly ILaserComponent _component;
        private readonly ISerializableVector3 _laserRotation;
        private readonly ISerializableVector3 _playerPosition;

        public LaserController(ICharacterModel player, ILaserContainer container)
        {
            _laserRotation = player.Storage.Get<ISerializableVector3>(Consts.LaserRotation);
            _container = container;
            _playerPosition = player.Storage.Get<ISerializableVector3>(Consts.Position);
            _component = player.GetConfig<IPlayerConfig>().GetComponent<ILaserComponent>(Consts.Laser);
        }

        protected override void OnInit()
        {
        }

        public void Update(float dt)
        {
            if(!_isInited) return;
            _container.DrawLineInDirection(_playerPosition.Get() + _component.PlayerOffset,_laserRotation.Get(), _component.LaserDistance);
        }

        protected override void OnDispose()
        {
        }
    }
}