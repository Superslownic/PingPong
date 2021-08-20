using System;
using UnityEngine;

namespace PingPong
{
    public class Ball : MonoBehaviour, ITarget
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _speed;
        
        private FreeMovement _movement;
        
        public void Init()
        {
            _movement = new FreeMovement(transform, _speed);
        }

        public void Push(Vector2 direction)
        {
            _movement.SetDirection(direction);
        }

        public void SetPosition(Vector2 position)
        {
            _movement.SetPosition(position);
        }

        public void Stop()
        {
            _movement.Stop();
        }
        
        private void FixedUpdate()
        {
            _movement.Update(Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 direction = Vector2.zero;

            foreach (var contact in collision.contacts)
                direction += contact.normal;

            direction = direction / collision.contacts.Length;

            _movement.Bounce(direction);
        }
    }
}
