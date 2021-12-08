using UnityEngine;

namespace Core.Interfaces.Controllers.Containers
{
    public interface ILocationContainer : IContainer
    {
        GameObject LocationRoot { get; }
    }
}