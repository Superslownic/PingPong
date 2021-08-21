using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class PaddleParameters : ScriptableObject
    {
        public Vector2 size;

        public Vector2 HalfSize => size * 0.5f;
    }
}
