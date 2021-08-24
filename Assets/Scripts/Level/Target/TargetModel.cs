using System;
using UnityEngine;

namespace PingPong
{
    public class TargetModel : Updatable
    {
        private IMovementStrategy _movement;
        private TargetView _view;
        private float _speed;

        public event Action<Collision2D> OnBounce;

        public TargetModel(TargetView view, TargetParameters parameters)
        {
            _view = view;
            _view.OnCollisionEnter.AddListener(Bounce);
            _view.SetSize(parameters.size);
            _speed = parameters.speed;
            _movement = new LinearBouncing();
        }

        public void Push(Vector2 direction)
        {
            _movement.SetDirection(direction);
        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(_view.gameObject);
        }

        public override void OnFixedUpdate(float delta)
        {
            if (_view == null)
                return;

            Vector2 velocity = _movement.Velocity * _speed * delta;
            _view.Move(velocity);
        }

        private void Bounce(Collision2D collision)
        {
            _movement.Bounce(collision);
            OnBounce?.Invoke(collision);
        }
    }
}
