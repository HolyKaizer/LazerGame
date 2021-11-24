namespace Core.Models.SceneLogic
{
    public abstract class BaseSceneLogic : ISceneLogic
    {
        protected readonly IMain _main;
        
        protected BaseSceneLogic(IMain main)
        {
            _main = main;
        }

        public abstract void InvokeLogic();
    }
}