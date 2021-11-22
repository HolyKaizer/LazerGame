using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Loading.Steps;

namespace Core.Loading
{
    internal sealed class GameLoader : IGameLoader
    {
        public bool IsComplete { get; private set; }
        
        private readonly LoaderContext _loaderContext;
        private readonly List<IGameLoadStep> _loadingSteps = new List<IGameLoadStep>();
        
        public GameLoader(LoaderContext loaderContext, Main main)
        {
            _loaderContext = loaderContext;

            _loadingSteps.Add(new FactoryStep(loaderContext, main));
            _loadingSteps.Add(new FilePathsStep(loaderContext, main));
            _loadingSteps.Add(new JsonReaderStep(loaderContext, main)); 
            _loadingSteps.Add(new RawSaveCreationStep(loaderContext, main));
            _loadingSteps.Add(new ConfigsCreationStep(loaderContext, main));
            _loadingSteps.Add(new ModelCreationStep(loaderContext, main));
            _loadingSteps.Add(new ContentLoadingStep(loaderContext, main));
            _loadingSteps.Add(new EntryControllerCreationStep(loaderContext, main));
            
            _loaderContext.StepsCount = _loadingSteps.Count;
        }

        public IEnumerator Load()
        {
            foreach (var step in _loadingSteps)
            {
                yield return step.Load();
            }

            IsComplete = true;
        }
    }
}