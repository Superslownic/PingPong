using UnityEngine;

namespace PingPong
{
    public class FreeMovement
    {
        private Transform _transform;
        private float _speed;
        private Vector2 _direction;

        public FreeMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
            _direction = Vector2.zero;
        }

        public void Update(float delta)
        {
            _transform.Translate(_direction * _speed * delta);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        
        public void Bounce(Vector2 normal)
        {
            _direction = Vector2.Reflect(_direction, normal);
        }

        public void SetPosition(Vector2 position)
        {
            _transform.localPosition = position;
        }

        public void Stop()
        {
            _direction = Vector2.zero;
        }
    }
}
