using Core.Interfaces.Controllers.Containers;
using UnityEngine;

namespace Core.Interfaces.Controllers
{
    public interface IRootContainerHolder : IContainer
    {
        Transform GetContainerRoot(string id);
    }
}