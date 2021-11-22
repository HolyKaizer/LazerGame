using System.Collections;

namespace Core.Loading.Steps
{
    internal sealed class ConfigsCreationStep : GameLoadStep
    {
        public override string StepId => "config_creation";
        
        public ConfigsCreationStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            //TODO: Add ScriptableObjects configs loading
            yield break;
        }
    }
}