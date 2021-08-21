using UnityEngine;

namespace PingPong
{
    public class TargetModel : ITargetModel
    {
        private IMovementStrategy _movement;
        private ITargetView _view;
        private float _speed;

        public TargetModel()
        {
            _movement = new BouncingZeroGravity();
        }

        public void SetSkin(TargetView view)
        {
            if (_view != null)
                _view.Destroy();

            _view = Object.Instantiate(view);
            Subscribe();
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

        public void SetPosition(Vector2 position)
        {
            _view.SetPosition(position);
        }

        public void Move(float deltaTime)
        {
            _view.Move(_movement.Velocity * _speed * deltaTime);
        }

        public void Stop()
        {
            _movement.Stop();
        }
        
        private void Unsubscribe()
        {
            _view.OnUpdate -= Move;
            _view.OnCollisionEnter -= _movement.Bounce;
            _view.OnDestroyed -= Unsubscribe;
        }

        private void Subscribe()
        {
            _view.OnUpdate += Move;
            _view.OnCollisionEnter += _movement.Bounce;
            _view.OnDestroyed += Unsubscribe;
        }
    }
}
