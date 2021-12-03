using System.Collections;
using Core.Interfaces;
using Core.Management;

namespace Core.Loading.Steps
{
    internal class JsonReaderStep : LoadStep
    {
        public override string StepId => "json_reader_step";
        public JsonReaderStep(LoaderContext context, IMain main) : base(context, main)
        {
        }
        
        protected override IEnumerator OnLoad()
        {
            var jsonFileReader = new JsonFileReader();

            _context.JsonFileReader = jsonFileReader;
            
            yield break;
        }
    }
}