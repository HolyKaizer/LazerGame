namespace Core.Interfaces
{
    public interface IMoveProcessor : ISave
    {
        public void ProcessMove(float dt);
    }
}