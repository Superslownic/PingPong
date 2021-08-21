using UnityEngine;

namespace PingPong
{
    public class PaddleModel
    {
        private PaddleView _view;
        private IInput _input;
        private RangeFloat _borders;
        private RangeFloat _movingRange;

        public PaddleModel(PaddleView view, IInput input, RangeFloat borders)
        {
            _view = view;
            _input = input;
            _borders = borders;

            _input.OnPointerDown += UpdatePosition;
            _input.OnDrag += UpdatePosition;
        }

        public void SetParameters(PaddleParameters parameters)
        {
            _view.SetSize(parameters.size);
            _movingRange = new RangeFloat();
            _movingRange.min = _borders.min + parameters.HalfSize.x;
            _movingRange.max = _borders.max - parameters.HalfSize.x;
        }

        private void UpdatePosition(float position)
        {
            _view.SetHorizontalPosition(Mathf.Clamp(position, _movingRange.min, _movingRange.max));
        }
    } 
}
