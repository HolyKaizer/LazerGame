using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Loading.Steps
{
    internal sealed class FilePathsStep : LoadStep
    {
        public override string StepId => "file_paths";
        
        public FilePathsStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            _context.FilePaths = new Dictionary<string, string>()
            {
                {"save", "Assets/save.json"},
                {"preload_atlas", "UI_Main_Atlas"}
            };
            
            yield break;
        }
    }
}