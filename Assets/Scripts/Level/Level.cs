using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class Level : MonoBehaviour
    {
        private TargetModel _target;
        private PaddleModel _paddle1;
        private PaddleModel _paddle2;
        private List<OutTrigger> _triggers;
        private SkinContainer _skinContainer;
        private TargetParametersContainer _targetParametersContainer;
        private PaddleParametersContainer _paddleParametersContainer;
        private ScoreModel _score;

        public void Init(
            Camera mainCamera, 
            IInput input, 
            SkinContainer targetSkinContainer, 
            TargetParametersContainer targetParametersContainer, 
            PaddleParametersContainer paddleParametersContainer, 
            PaddleView paddleView1, 
            PaddleView paddleView2,
            ScoreView scoreView)
        {
            _skinContainer = targetSkinContainer;
            _targetParametersContainer = targetParametersContainer;
            _paddleParametersContainer = paddleParametersContainer;
            _triggers = new List<OutTrigger>();

            CreateScore(scoreView);
            CreateTarget();
            CreatePaddles(mainCamera, input, paddleParametersContainer, paddleView1, paddleView2);
            CreateBorders(mainCamera);

            ResetLevel();
        }
        
        private void OnDestroy()
        {
            foreach (var trigger in _triggers)
                trigger.OnOut -= ResetLevel;
        }

        private void CreateTarget()
        {
            _target = new TargetModel(Instantiate(_skinContainer.GetRandom()));
            _target.OnPaddleBounce += _score.AddScore;
        }

        private void CreatePaddles(Camera mainCamera, IInput input, PaddleParametersContainer paddleParametersContainer, PaddleView paddleView1, PaddleView paddleView2)
        {
            RangeFloat borders = new RangeFloat(mainCamera.LeftBorder(), mainCamera.RightBorder());

            _paddle1 = new PaddleModel(paddleView1, input, borders);
            _paddle2 = new PaddleModel(paddleView2, input, borders);
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

        private void CreateScore(ScoreView scoreView)
        {
            _score = new ScoreModel(0);
            scoreView.Ctor(_score);
        }

        private void SetupOutTrigger(EdgeCollider2D edge)
        {
            OutTrigger trigger = edge.gameObject.AddComponent<OutTrigger>();
            trigger.OnOut += ResetLevel;
            _triggers.Add(trigger);
        }

        private void ResetLevel()
        {
            SetRandomParameters();
            _target.Stop();
            _target.Reset(Vector2.zero);
            _target.Push(Random.insideUnitCircle.normalized);
            _score.ResetScore();
        }

        private void SetRandomParameters()
        {
            _target.SetParameters(_targetParametersContainer.GetRandom());

            PaddleParameters paddleParameters = _paddleParametersContainer.GetRandom();

            _paddle1.SetParameters(paddleParameters);
            _paddle2.SetParameters(paddleParameters);
        }
    }
}
