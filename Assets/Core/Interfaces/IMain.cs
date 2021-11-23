using Core.Configs;

namespace Core
{
    public interface IMain
    {
        MainConfig MainConfig { get; }
        InputViewModel InputViewModel { get; }
#if LG_DEVELOP
        bool IsTest { get; }
#endif
    }
}