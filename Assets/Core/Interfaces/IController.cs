using System;

namespace Core.Interfaces
{
    internal interface IController : IDisposable
    {
        void Init();
    }
}