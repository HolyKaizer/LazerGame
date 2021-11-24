namespace Core.Models.SceneLogic
{
    public sealed class EmptySceneLogic : BaseSceneLogic
    {
        public EmptySceneLogic(IMain main) : base(main)
        {
        }

        public override void InvokeLogic()
        {
        }
    }
}