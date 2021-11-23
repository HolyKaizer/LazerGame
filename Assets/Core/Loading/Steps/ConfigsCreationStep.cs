using System.Collections;

namespace Core.Loading.Steps
{
    internal sealed class ConfigsCreationStep : LoadStep
    {
        public override string StepId => "config_creation";
        
        public ConfigsCreationStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            _context.MainConfig = _main.MainConfig;
            yield break;
        }
    }
}