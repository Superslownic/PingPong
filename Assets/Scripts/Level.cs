using UnityEngine;

namespace PingPong
{
    public class Level : MonoBehaviour
    {
        public void Init(Camera mainCamera)
        {
            CreateBorders(mainCamera);
        }

        private void CreateBorders(Camera camera)
        {
            var edgeBuilder = new EdgeColliderBuilder();

            Vector2 lDCorner = camera.LDCornerToWorld();
            Vector2 rUCorner = camera.RUCornerToWorld();

            edgeBuilder.CreateEdge(
                "LeftBorder",
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                );

            edgeBuilder.CreateEdge(
                "RightBorder",
                transform,
                new Vector2(rUCorner.x, rUCorner.y),
                new Vector2(rUCorner.x, lDCorner.y)
                );
            
            MakeEdgeAsTrigger(
                edgeBuilder.CreateEdge(
                "TopTrigger",
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                ));

            MakeEdgeAsTrigger(
                edgeBuilder.CreateEdge(
                "BottomTrigger",
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                ));
        }

        private void MakeEdgeAsTrigger(EdgeCollider2D edge)
        {
            edge.isTrigger = true;
            edge.gameObject.AddComponent<OutTrigger>();
        }
    }
}
