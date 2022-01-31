using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers.Containers;
using Core.Interfaces.Models;

namespace Core.Controllers
{
    internal class HealthController : BaseController
    {
        private readonly IHealthProcessor _healthProcessor;

        public HealthController(IMain main, IContainer parentContainer, ICharacterModel model)
        {
            _healthProcessor = model.GetProcessor<IHealthProcessor>(model.GetConfig<ICharacterConfig>().GetComponent<IHealthComponent>(Consts.HealthComponent));
        }

        protected override void OnInit()
        {
            _healthProcessor.Died += OnDied;
        }

        private void OnDied(IModel obj)
        {
            CustomLogger.Log($"{obj.Id} char died");
            //TODO: die process 
        }

        protected override void OnDispose()
        {
            _healthProcessor.Died -= OnDied;
        }
    }
}