using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Controllers;

namespace Core.Controllers
{
    public sealed class EntryGameController : BaseController, IEntryGameController
    {
        private readonly ICollection<IController> _startControllers = new HashSet<IController>();

        private readonly IController _inputController;
        private readonly ILoaderContext _context;
        private readonly IMain _main;

        public EntryGameController(IMain main)
        {
            _context = main.LoaderContext;
            _main = main;
            _inputController = new InputController(main.MainConfig.ActionAsset.FindActionMap(Consts.Player), main.InputViewModel.RotateInputViewModel);
        }

        protected override void OnInit()
        {
            if (_context.RawSaves != null)
            {
                _context.UserData.Load(_context.RawSaves);
            }
            _inputController.Init();

            AddAndInitStartControllers();
        }

        private void AddAndInitStartControllers()
        {
            foreach (var model in _context.UserData.GetStartModels())
            {
                var config = model.GetConfig<ITypedConfig>();
                if (!config.GetTags().Contains(Consts.HasController)) continue;
               
                var controller = config is IAddressablesPrefabConfig
                    ? ControllerFactoryManager.Factory.Build<IController>(config.Type, _main, _main.MainSceneContainer, model)
                    : ControllerFactoryManager.Factory.Build<IController>(config.Type, _main, model);
               
                controller.Init();
                _startControllers.Add(controller);
            }
        }

        public void Update(float dt)
        {
            if(!_isInited) return;
            
            foreach (var controller in _startControllers)
            {
                if(controller is IUpdatable updatable) 
                    updatable.Update(dt);
            }
        }
        
        protected override void OnDispose()
        {
            foreach (var controller in _startControllers)
            {
                controller.Dispose();
            }
            _inputController.Dispose();
            
            var saveData = _context.UserData.Save(new Dictionary<string, object>());
            _context.JsonFileReader.Save(saveData, _context.FilePaths["save"]);
        }
    }
}