using UnityEngine;

namespace PingPong
{
    public interface ITarget
    {
        void Stop();
        void SetPosition(Vector2 position);
        void Push(Vector2 direction);
    }
}
