using System.Collections;
using Core.Factory;

namespace Core.Loading.Steps
{
    internal sealed class FactoryStep : LoadStep
    {
        public override string StepId => "factory_step";
        
        public FactoryStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            FactoryManager.Init();
            yield break;
        }
    }
}