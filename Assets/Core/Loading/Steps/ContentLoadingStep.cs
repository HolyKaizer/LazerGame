using System.Collections;
using UnityEngine.AddressableAssets;

namespace Core.Loading.Steps
{
    internal class ContentLoadingStep : GameLoadStep
    {
        public ContentLoadingStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        public override string StepId => "content_loading";
        
        protected override IEnumerator OnLoad()
        {
            _context.ContentManager = new ContentManager();
            yield return _context.ContentManager.LoadAtlas(_context.FilePaths["preload_atlas"]);
        }
    }
}