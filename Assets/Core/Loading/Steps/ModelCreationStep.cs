using System.Collections;
using Core.Models;

namespace Core.Loading.Steps
{
    internal sealed class ModelCreationStep : GameLoadStep
    {
        public override string StepId => "model_creation";
        
        public ModelCreationStep(LoaderContext context, Main main) : base(context, main)
        {
        }

        protected override IEnumerator OnLoad()
        {
            _context.UserData = new UserData(Consts.UserDataId, _context.MainConfig);
            
            if (_context.RawSaves != null)
            {
                _context.UserData.Deserialize(_context.RawSaves);
            }
            
            
            yield break;
        }
    }
}