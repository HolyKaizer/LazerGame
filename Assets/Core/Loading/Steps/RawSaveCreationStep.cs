using System.Collections;
using System.Collections.Generic;

namespace Core.Loading.Steps
{
    internal class RawSaveCreationStep : GameLoadStep
    {
        public override string StepId => "raw_save_creation_step";
        
        public RawSaveCreationStep(LoaderContext context, Main main) : base(context, main)
        {
        }
        
        protected override IEnumerator OnLoad()
        {
            _context.RawSaves = _context.JsonFileReader.Load<Dictionary<string, object>>(_context.FilePaths["save"]);

            yield break;
        }
    }
}