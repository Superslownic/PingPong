using UnityEngine;

namespace PingPong
{
    public interface IMovementStrategy
    {
        Vector2 Velocity { get; }
        void Stop();
        void SetDirection(Vector2 direction);
        void Bounce(Collision2D collision);
    }
}
