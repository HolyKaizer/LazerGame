using System;

namespace Core.Interfaces
{
    internal interface ISceneManager
    {
        event Action OnSceneLoaded;
        event Action OnUnloadScene;
        bool SceneLoading { get;  }
        bool IsGameReady { get;  } 
        double StartSwitchLevelTs { get; }
    }
}