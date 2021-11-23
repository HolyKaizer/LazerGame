using System.Collections;
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
            _context.UserData = new UserData(Consts.UserDataId, _context.MainConfig);
            
            yield break;
        }
    }
}