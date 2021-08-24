using UnityEngine;

namespace PingPong
{
    public class PaddleFactory
    {
        private IInput _input;
        private Camera _mainCamera;
        private PaddleParametersContainer _paddleParametersContainer;
        private PaddleView _viewPrefab;

        public PaddleFactory(IInput input, Camera mainCamera, PaddleParametersContainer paddleParametersContainer, PaddleView viewPrefab)
        {
            _input = input;
            _mainCamera = mainCamera;
            _paddleParametersContainer = paddleParametersContainer;
            _viewPrefab = viewPrefab;
        }

        public PaddleModel Create(Transform parent)
        {
            RangeFloat borders = new RangeFloat(_mainCamera.LeftBorder(), _mainCamera.RightBorder());

            var view = Object.Instantiate(_viewPrefab, parent.position, Quaternion.identity, parent);
            var model = new PaddleModel(view, _input, borders);
            model.SetParameters(_paddleParametersContainer.Any());

            return model;
        }
    }
}
