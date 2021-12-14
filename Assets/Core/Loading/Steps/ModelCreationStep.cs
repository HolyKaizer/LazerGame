using System.Collections;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;

namespace Core.Loading.Steps
{
    internal sealed class ModelCreationStep : LoadStep
    {
        public override string StepId => "model_creation";
        
        public ModelCreationStep(LoaderContext context, IMain main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            _context.UserData = _context.RawSaves != null 
                ? new UserData(Consts.UserDataId, _main.Engine, _context.MainConfig, _context.RawSaves)
                : new UserData(Consts.UserDataId, _main.Engine, _context.MainConfig);

            yield break;
        }
    }
}