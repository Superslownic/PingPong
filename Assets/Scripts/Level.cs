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
            
            edgeBuilder.CreateEdge(
                "TopTrigger",
                true,
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                ).gameObject.AddComponent<OutTrigger>();
            
            edgeBuilder.CreateEdge(
                "BottomTrigger",
                true,
                transform,
                new Vector2(lDCorner.x, lDCorner.y),
                new Vector2(lDCorner.x, rUCorner.y)
                ).gameObject.AddComponent<OutTrigger>();
        }
    }
}
