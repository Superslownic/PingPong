using UnityEngine;

namespace PingPong
{
    public class TargetModel : ITargetModel
    {
        private IMovementStrategy _movement;
        private ITargetView _view;

        public TargetModel(IMovementStrategy movement)
        {
            _movement = movement;
        }

        public void SetTheme(Theme theme)
        {
            if (_view != null)
                _view.Destroy();

            var customizer = new Customizer();
            theme.Accept(customizer);

            _view = customizer.View;
            Subscribe();
        }

        public void Push(Vector2 direction)
        {
            _movement.SetDirection(direction);
        }

        public void SetPosition(Vector2 position)
        {
            _view.SetPosition(position);
        }

        public void Move()
        {
            _view.Move(_movement.Velocity);
        }

        public void Stop()
        {
            _movement.Stop();
        }
        
        public void Setup(Parameters parameters)
        {
            
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
