using System;

namespace PingPong
{
    public interface IResettable
    {
        event Action OnReset;
        void Reset();
    }
}
