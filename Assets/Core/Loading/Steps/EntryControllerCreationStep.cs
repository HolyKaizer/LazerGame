using System.Collections;
using Core.Controllers;

namespace Core.Loading.Steps
{
    internal class EntryControllerCreationStep : LoadStep
    {
        public EntryControllerCreationStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        public override string StepId => "controllers_creation_loading";
        
        protected override IEnumerator OnLoad()
        {
            _context.EntryGameController = new EntryGameController(_context, _main);
            _context.IsLoadDone = true;
            yield break;
        }
    }
}