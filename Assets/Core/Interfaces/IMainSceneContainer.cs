using UnityEngine;

namespace Core.Interfaces
{
    public interface IMainSceneContainer
    { 
        GameObject LocationRoot { get; }
        GameObject UiRoot { get; }
        RectTransform UiRectTransform { get; }
    }
}