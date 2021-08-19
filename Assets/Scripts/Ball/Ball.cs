using UnityEngine;

namespace PingPong
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _speed;
        
        private FreeMovement _movement;

        private void Awake()
        {
            _movement = new FreeMovement(transform, _speed);
            _movement.SetDirection(Random.insideUnitCircle.normalized);
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
