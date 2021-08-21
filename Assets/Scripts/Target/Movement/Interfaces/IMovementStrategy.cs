using UnityEngine;

namespace PingPong
{
    public interface IMovementStrategy
    {
        Vector2 Velocity { get; }
        void SetDirection(Vector2 direction);
        void Bounce(Collision2D collision);
        void Stop();
    }
}
