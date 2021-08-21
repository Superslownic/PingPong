using System;
using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class TargetView : MonoBehaviour, ITargetView
    {
        private Rigidbody2D _rigidbody;

        public event Action<float> OnUpdate;
        public event Action<Collision2D> OnCollisionEnter;
        public event Action OnDestroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            LocalAwake();
        }

        private void FixedUpdate()
        {
            OnUpdate?.Invoke(Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
            LocalOnCollisionEnter(collision);
        }

        public void Move(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void Destroy()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public void SetSize(Vector3 size)
        {
            transform.localScale = size;
        }

        protected abstract void LocalAwake();
        protected abstract void LocalOnCollisionEnter(Collision2D collision);
    }
}
