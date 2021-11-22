using System.Collections.Generic;
using Core.Loading;

namespace Core.Controllers
{
    internal sealed class EntryGameController : BaseController
    {
        private readonly ILoaderContext _context;
        private readonly Main _main;

        public EntryGameController(ILoaderContext context, Main main)
        {
            _context = context;
            _main = main;
        }

        protected override void OnInit()
        {
            
        }

        protected override void OnDispose()
        {
            var saveData = _context.UserData.Serialize(new Dictionary<string, object>());
            _context.JsonFileReader.Save(saveData, _context.FilePaths["save"]);
        }
    }
}