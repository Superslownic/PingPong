using UnityEngine;

namespace PingPong
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private MobileInput _input;
        [SerializeField] private Paddle _paddle;
        [SerializeField] private Paddle _paddle1;
        [SerializeField] private Ball _ball;
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Level _level;

        private void Awake()
        {
            _input.Init(_uiCamera);
            _paddle.Init(_input, _mainCamera);
            _paddle1.Init(_input, _mainCamera);
            _level.Init(_mainCamera);
        }
    } 
}
