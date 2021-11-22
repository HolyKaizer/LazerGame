using System.Collections;
using Core.Controllers;

namespace Core.Loading.Steps
{
    internal class EntryControllerCreationStep : GameLoadStep
    {
        public EntryControllerCreationStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        public override string StepId => "controllers_creation_loading";
        
        protected override IEnumerator OnLoad()
        {
            _context.EntryGameController = new EntryGameController(_context, _main);
            _context.EntryGameController.Init();
            
            _context.IsLoadDone = true;
            yield break;
        }
    }
}