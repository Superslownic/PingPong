using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _targetParent;
        [SerializeField] private Transform _bottomPaddleParent;
        [SerializeField] private Transform _topPaddleParent;

        private TargetFactory _targetFactory;
        private PaddleFactory _paddleFactory;
        private TargetModel _target;
        private PaddleModel _bottomPaddle;
        private PaddleModel _topPaddle;
        private List<OutTrigger> _triggers;
        private ScoreModel _score;

        public Level Ctor(TargetFactory targetFactory, PaddleFactory paddleFactory, Camera mainCamera, ScoreModel score)
        {
            _targetFactory = targetFactory;
            _paddleFactory = paddleFactory;
            _score = score;
            _triggers = new List<OutTrigger>();
            
            CreateBorders(mainCamera);

            return this;
        }

        public void Play()
        {
            if (_target != null)
                _target.Destroy();

            _target = _targetFactory.Create(_targetParent);
            _target.OnBounce += HandleTargetCollision;
            _target.Push(Random.insideUnitCircle.normalized);

            if (_bottomPaddle != null)
                _bottomPaddle.Destroy();

            _bottomPaddle = _paddleFactory.Create(_bottomPaddleParent);

            if (_topPaddle != null)
                _topPaddle.Destroy();

            _topPaddle = _paddleFactory.Create(_topPaddleParent);

            _score.ResetScore();
        }

        public void Stop()
        {
            if (_target != null)
            {
                _target.Destroy();
                _target = null;
            }

            _score.ResetScore();
        }
        
        private void OnDestroy()
        {
            foreach (var trigger in _triggers)
                trigger.OnOut -= Play;
        }

        private void CreateBorders(Camera camera)
        {
            var edgeBuilder = new EdgeColliderBuilder();

            Vector2 lDCorner = camera.LDCornerToWorld();
            Vector2 rUCorner = camera.RUCornerToWorld();

            edgeBuilder.CreateEdge(
                "LeftBorder",
                false,
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                );

            edgeBuilder.CreateEdge(
                "RightBorder",
                false,
                transform,
                new Vector2(rUCorner.x, rUCorner.y),
                new Vector2(rUCorner.x, lDCorner.y)
                );

            SetupOutTrigger(
                edgeBuilder.CreateEdge(
                    "TopTrigger",
                    true,
                    transform,
                    new Vector2(lDCorner.x, rUCorner.y),
                    new Vector2(rUCorner.x, rUCorner.y)
                ));

            SetupOutTrigger(
                edgeBuilder.CreateEdge(
                    "BottomTrigger",
                    true,
                    transform,
                    new Vector2(lDCorner.x, lDCorner.y),
                    new Vector2(rUCorner.x, lDCorner.y)
                ));
        }
        
        private void SetupOutTrigger(EdgeCollider2D edge)
        {
            OutTrigger trigger = edge.gameObject.AddComponent<OutTrigger>();
            trigger.OnOut += Play;
            _triggers.Add(trigger);
        }
        
        private void HandleTargetCollision(Collision2D collision)
        {
            if (collision.transform.HasComponent<PaddleView>())
                _score.AddScore();
        }
    }
}
