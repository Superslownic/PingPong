using UnityEngine;

namespace PingPong
{
    public class Paddle : MonoBehaviour
    {
        private IInput _input;
        private float _leftBorder;
        private float _rightBorder;

        public void Init(IInput input, Camera camera)
        {
            _input = input;

            float halfWidth = transform.localScale.x / 2;

            _leftBorder = camera.LeftBorder() + halfWidth;
            _rightBorder = camera.RightBorder() - halfWidth;
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
