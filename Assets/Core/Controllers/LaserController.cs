using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    internal sealed class LaserController : BaseController, IUpdatable
    {
        private readonly ILaserModel _model;
        private readonly ILaserContainer _container;
        private readonly ISerializableVector3 _playerPosition;
        private readonly ILaserConfig _config;
        
        public LaserController(ICharacterModel player, ILaserModel model, ILaserContainer container)
        {
            _model = model;
            _container = container;
            _playerPosition = player.Storage.Get<ISerializableVector3>(Consts.Position);
            _config = model.GetConfig<ILaserConfig>();
        }

        protected override void OnInit()
        {
        }

        public void Update(float dt)
        {
            if(!_isInited) return;
            _container.DrawLineInDirection(_playerPosition.Get() + _config.PlayerOffset,_model.LaserRotation.Get(), _config.LaserDistance);
        }

        protected override void OnDispose()
        {
        }
    }
}