using System.Collections;
using System.Collections.Generic;

namespace Core.Loading.Steps
{
    internal sealed class FilePathsStep : GameLoadStep
    {
        public override string StepId => "file_paths";
        
        public FilePathsStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            _context.FilePaths = new Dictionary<string, string>()
            {
                {"save", "Assets/Scripts/Save/save.json"},
                {"preload_atlas", "UI_Main_Atlas"}
            };
            
            yield break;
        }
    }
}