using System.Collections;
using Core.Extensions;
using Core.Interfaces;
using Core.Systems;

namespace Core.Loading.Steps
{
    internal sealed class EngineInitializationStep : LoadStep
    {
        public override string StepId => "config_creation";
        
        public EngineInitializationStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            var modelLogicSystem = new UpdateSystem(Consts.LogicSystem);
            var controllersSystem = new UpdateSystem(Consts.ControllersSystem);
            var physicsSystem = new FixedUpdateSystem(Consts.PhysicsSystem);
            
            _main.Engine.Add(physicsSystem);
            _main.Engine.Add(modelLogicSystem);
            _main.Engine.Add(controllersSystem);
            
            yield break;
        }
    }
}