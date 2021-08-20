using UnityEngine;

namespace PingPong
{
    public class BouncingZeroGravity : IMovementStrategy
    {
        private float _speed;
        private Vector2 _direction;

        public Vector2 Velocity => _direction * _speed;

        public BouncingZeroGravity(float speed)
        {
            _speed = speed;
            _direction = Vector2.zero;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void Bounce(Collision2D collision)
        {
            Vector2 normal = Vector2.zero;

            foreach (var contact in collision.contacts)
                normal += contact.normal;

            normal = normal / collision.contacts.Length;

            SetDirection(Vector2.Reflect(_direction, normal));
        }

        public void Stop()
        {
            SetDirection(Vector2.zero);
        }
    }
}
