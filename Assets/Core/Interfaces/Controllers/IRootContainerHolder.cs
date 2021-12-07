using UnityEngine;

namespace Core.Interfaces.Controllers
{
    public interface IRootContainerHolder
    {
        Transform GetContainerRoot(string id);
    }
}