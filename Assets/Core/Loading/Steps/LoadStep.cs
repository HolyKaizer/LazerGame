using System.Collections;
using Core.Interfaces;

namespace Core.Loading.Steps
{
    internal abstract class LoadStep : ILoadStep
    {
        public bool IsCompleted { get; protected set; }
        
        public abstract string StepId { get; }
        
        protected readonly LoaderContext _context;
        protected readonly IMain _main;

        protected LoadStep(LoaderContext context, IMain main)
        {
            _context = context;
            _main = main;
        }

        public IEnumerator Load()
        {
            CustomLogger.Log($"Loading step=\"{StepId}\" started");
            yield return OnLoad();
        }

        protected abstract IEnumerator OnLoad();
    }
}