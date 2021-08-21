using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class Level : MonoBehaviour
    {
        private ITargetModel _target;
        private List<OutTrigger> _triggers;
        private SkinContainer _skinContainer;
        private ParametersContainer _parametersContainer;

        public void Init(Camera mainCamera, SkinContainer skinContainer, ParametersContainer parametersContainer)
        {
            _skinContainer = skinContainer;
            _parametersContainer = parametersContainer;
            _target = new TargetModel();
            _triggers = new List<OutTrigger>();

            CreateBorders(mainCamera);
            ResetLevel();
        }

        private void OnDestroy()
        {
            foreach (var trigger in _triggers)
                trigger.OnOut -= ResetLevel;
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
            trigger.OnOut += ResetLevel;
            _triggers.Add(trigger);
        }

        private void ResetLevel()
        {
            _target.SetSkin(_skinContainer.GetRandom());
            _target.SetParameters(_parametersContainer.GetRandom());
            _target.Stop();
            _target.SetPosition(Vector2.zero);
            _target.Push(Random.insideUnitCircle.normalized);
        }
    }
}
