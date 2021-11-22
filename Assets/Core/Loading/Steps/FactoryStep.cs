using System.Collections;

namespace Core.Loading.Steps
{
    internal sealed class FactoryStep : GameLoadStep
    {
        public override string StepId => "factory_step";
        
        public FactoryStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            //TODO: create factory manager step
            yield break;
        }
    }
}