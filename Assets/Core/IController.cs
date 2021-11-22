using System;

namespace Core
{
    internal interface IController : IDisposable
    {
        void Init();
    }
}