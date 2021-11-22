using System;
using System.Collections;
using Core.Interfaces;
using UnityEngine;

namespace Core.Loading.Steps
{
    internal abstract class GameLoadStep : IGameLoadStep
    {
        public bool IsCompleted { get; protected set; }
        
        public abstract string StepId { get; }
        
        protected readonly LoaderContext _context;
        protected readonly Main _main;

        protected GameLoadStep(LoaderContext context, Main main)
        {
            _context = context;
            _main = main;
        }

        public IEnumerator Load()
        {
#if LG_DEVELOP
            Debug.Log($"Loading step=\"{StepId}\" started");
#endif
            
            yield return OnLoad();
        }

        protected abstract IEnumerator OnLoad();
    }
}