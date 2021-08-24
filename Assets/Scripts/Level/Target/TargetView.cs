using UnityEngine;
using UnityEngine.Events;

namespace PingPong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TargetView : MonoBehaviour
    {
        public UnityEvent<Collision2D> OnCollisionEnter;

        private Rigidbody2D _rigidbody;
        private TargetModel _model;

        public TargetView Ctor()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            return this;
        }

        public void SetSize(Vector3 size)
        {
            transform.localScale = size;
        }

        public void Move(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
        }
    }
}
