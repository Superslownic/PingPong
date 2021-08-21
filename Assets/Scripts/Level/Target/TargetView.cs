using System;
using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class TargetView : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        public event Action<Collision2D> OnCollisionEnter;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            ForwardedAwake();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
            ForwardedOnCollisionEnter(collision);
        }

        public void Move(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetSize(Vector3 size)
        {
            transform.localScale = size;
        }

        public void Reset(Vector2 position)
        {
            transform.position = position;
            ForwardedReset();
        }

        protected abstract void ForwardedAwake();
        protected abstract void ForwardedOnCollisionEnter(Collision2D collision);
        protected abstract void ForwardedReset();
    }
}
