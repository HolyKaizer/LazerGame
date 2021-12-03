namespace Core.Interfaces
{
    public interface IJsonFileReader
    {
        void Save<T>(T data, string path = null);
        T Load<T>(string path = null);
    }
}