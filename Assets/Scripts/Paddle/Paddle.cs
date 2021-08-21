using NaughtyAttributes;
using UnityEngine;

namespace PingPong
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField, Range(1, 10), OnValueChanged(nameof(SetWidth))] private float _width;

        private IInput _input;
        private float _leftBorder;
        private float _rightBorder;

        public void Init(IInput input, Camera camera)
        {
            _input = input;

            float width = transform.localScale.x;

            _leftBorder = camera.LeftBorder() + width;
            _rightBorder = camera.RightBorder() - width;
        }

        public void SetWidth()
        {
            Vector2 size = new Vector2(_width, 1);
            GetComponent<SpriteRenderer>().size = size;
            GetComponent<BoxCollider2D>().size = size;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            position.x = _input.TouchPosition.x;
            position.x = Mathf.Clamp(position.x, _leftBorder, _rightBorder);
            transform.position = position;
        }
    } 
}
