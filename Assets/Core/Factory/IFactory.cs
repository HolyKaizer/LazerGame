namespace Core.Factory
{
    public interface IFactory
    {
        T Build<T>(string key, params object[] arguments);
        object Build(params object[] arguments);
    }
}