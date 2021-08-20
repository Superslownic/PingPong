using UnityEngine;

namespace PingPong
{
    public class EdgeColliderBuilder
    {
        public EdgeCollider2D CreateEdge(string name, bool isTrigger, params Vector2[] points)
        {
            EdgeCollider2D edge = new GameObject(name).AddComponent<EdgeCollider2D>();
            edge.points = points;

            return edge;
        }

        public EdgeCollider2D CreateEdge(string name, bool isTrigger, Transform parent, params Vector2[] points)
        {
            EdgeCollider2D edge = CreateEdge(name, isTrigger, points);
            edge.transform.parent = parent;

            return edge;
        }
    }
}
