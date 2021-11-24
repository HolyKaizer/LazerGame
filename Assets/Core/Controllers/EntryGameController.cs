using System.Collections.Generic;
using Core.Interfaces;
using Core.Loading;

namespace Core.Controllers
{
    public sealed class EntryGameController : BaseController
    {
        private readonly ILoaderContext _context;
        private readonly IController _inputController;

        public EntryGameController(ILoaderContext context, IMain main)
        {
            _context = context;
            _inputController = new InputController(main.MainConfig.ActionAsset.FindActionMap(Consts.Player), main.InputViewModel.RotateInputViewModel);
        }

        protected override void OnInit()
        {
            if (_context.RawSaves != null)
            {
                _context.UserData.Deserialize(_context.RawSaves);
            }
            
            _inputController.Init();
        }

        protected override void OnDispose()
        {
            _inputController.Dispose();
            
            var saveData = _context.UserData.Serialize(new Dictionary<string, object>());
            _context.JsonFileReader.Save(saveData, _context.FilePaths["save"]);
        }
    }
}