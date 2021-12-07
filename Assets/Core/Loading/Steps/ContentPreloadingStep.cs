using System.Collections;
using Core.Interfaces;
using Core.Management;

namespace Core.Loading.Steps
{
    internal class ContentPreloadingStep : LoadStep
    {
        public ContentPreloadingStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        public override string StepId => "content_loading";
        
        protected override IEnumerator OnLoad()
        {
            _context.ContentManager = new ContentManager(_context, _context.FilePaths["preload_atlas"]);
          
            yield return _context.ContentManager.BundleLoader.LoadForWarmup();
        }
    }
}