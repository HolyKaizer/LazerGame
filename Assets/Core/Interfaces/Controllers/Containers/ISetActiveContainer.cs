namespace Core.Interfaces.Controllers.Containers
{
    public interface ISetActiveContainer : IContainer
    {
        void SetActive(bool value);
    }
}