using System;

namespace Core.Interfaces.Controllers
{
    public interface IController : IDisposable
    {
        void Init();
    }
}