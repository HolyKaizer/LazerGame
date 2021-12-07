using UnityEngine;

namespace Core.Interfaces.Controllers.Containers
{
    public interface IMainSceneContainer : IRootContainerHolder
    { 
        Transform LocationRoot { get; }
        GameObject UiRoot { get; }
        RectTransform UiRectTransform { get; }
    }
}