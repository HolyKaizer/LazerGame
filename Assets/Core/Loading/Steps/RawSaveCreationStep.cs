using System.Collections;
using System.Collections.Generic;

namespace Core.Loading.Steps
{
    internal class RawSaveCreationStep : LoadStep
    {
        public override string StepId => "raw_save_creation_step";
        
        public RawSaveCreationStep(LoaderContext context, IMain main) : base(context, main)
        {
        }
        
        protected override IEnumerator OnLoad()
        {
            _context.RawSaves = _context.JsonFileReader.Load<Dictionary<string, object>>(_context.FilePaths["save"]);

            yield break;
        }
    }
}