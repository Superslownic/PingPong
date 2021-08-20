using UnityEngine;

namespace PingPong
{
    public class EdgeColliderBuilder
    {
        public EdgeCollider2D CreateEdge(string name, params Vector2[] points)
        {
            EdgeCollider2D edge = new GameObject(name).AddComponent<EdgeCollider2D>();
            edge.points = points;

            return edge;
        }

        public EdgeCollider2D CreateEdge(string name, Transform parent, params Vector2[] points)
        {
            EdgeCollider2D edge = CreateEdge(name, points);
            edge.transform.parent = parent;

            return edge;
        }
    }
}
