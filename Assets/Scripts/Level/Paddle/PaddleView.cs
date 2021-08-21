using UnityEngine;

namespace PingPong
{
    public class PaddleView : MonoBehaviour
    {
        public void SetSize(Vector2 size)
        {
            transform.localScale = size;
        }

        public void SetHorizontalPosition(float value)
        {
            Vector2 position = transform.position;
            position.x = value;
            transform.position = position;
        }
    }
}
