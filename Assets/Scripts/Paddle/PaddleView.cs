using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PaddleView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public void SetSize(Vector2 size)
        {
            _spriteRenderer.size = size;
            _boxCollider.size = size;
        }

        public void SetHorizontalPosition(float value)
        {
            Vector2 position = transform.position;
            position.x = value;
            transform.position = position;
        }
    }
}
