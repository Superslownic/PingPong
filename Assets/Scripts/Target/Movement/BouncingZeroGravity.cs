using UnityEngine;

namespace PingPong
{
    public class BouncingZeroGravity : IMovementStrategy
    {
        public Vector2 Velocity { get; private set; }

        public BouncingZeroGravity()
        {
            Velocity = Vector2.zero;
        }

        public void SetDirection(Vector2 direction)
        {
            Velocity = direction;
        }

        public void Bounce(Collision2D collision)
        {
            Vector2 normal = Vector2.zero;

            foreach (var contact in collision.contacts)
                normal += contact.normal;

            normal = normal / collision.contacts.Length;

            SetDirection(Vector2.Reflect(Velocity, normal));
        }

        public void Stop()
        {
            SetDirection(Vector2.zero);
        }
    }
}
