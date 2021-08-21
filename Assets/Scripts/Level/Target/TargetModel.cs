using System;
using UnityEngine;

namespace PingPong
{
    public class TargetModel : Updatable
    {
        private IMovementStrategy _movement;
        private TargetView _view;
        private float _speed;

        public event Action OnPaddleBounce;

        public TargetModel(TargetView view)
        {
            _movement = new LinearBouncing();
            _view = view;
            _view.OnCollisionEnter += Bounce;
        }

        public void SetParameters(TargetParameters parameters)
        {
            _speed = parameters.speed;
            _view.SetSize(parameters.size);
        }

        public void Push(Vector2 direction)
        {
            _movement.SetDirection(direction);
        }

        public void Reset(Vector2 position)
        {
            _view.Reset(position);
        }

        public void Move(float deltaTime)
        {
            _view.Move(_movement.Velocity * _speed * deltaTime);
        }

        public void Stop()
        {
            _movement.Stop();
        }

        public override void OnFixedUpdate(float delta)
        {
            Move(delta);
        }

        private void Bounce(Collision2D collision)
        {
            _movement.Bounce(collision);
            if (collision.transform.HasComponent<PaddleView>())
                OnPaddleBounce?.Invoke();
        }
    }
}
