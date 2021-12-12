namespace Core.Interfaces
{
    public interface ILoadingProcess
    {
        void SetLoadingComplete();
        bool IsLoadingCompleted { get; }
        float CurLoadingProgress { get; }
        void SetLoadingProgress(float value);
    }
}