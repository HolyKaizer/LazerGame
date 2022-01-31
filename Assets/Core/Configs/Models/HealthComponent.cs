using Core.Extensions;
using Core.Interfaces.Configs;
using UnityEngine;

namespace Core.Configs.Models
{
    [CreateAssetMenu(menuName = "EndlessSoftware/Components/HealthComponent", fileName = "HealthComponent")]
    public sealed class HealthComponent : BaseComponent, IHealthComponent, IHasController
    {
        [SerializeField] private float _startHeath;
        public override string Id => Consts.HealthComponent;
        public string LogicId => Consts.HealthProcessor;
        public string ControllerType => Consts.Health;

        public float StartHeath => _startHeath;
    }
}