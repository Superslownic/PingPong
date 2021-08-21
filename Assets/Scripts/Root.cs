using UnityEngine;

namespace PingPong
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private MobileInput _input;
        [SerializeField] private PaddleView _paddleView1;
        [SerializeField] private PaddleView _paddleView2;
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Level _level;
        [SerializeField] private SkinContainer _skinContainer;
        [SerializeField] private TargetParametersContainer _targetParametersContainer;
        [SerializeField] private PaddleParametersContainer _paddleParametersContainer;
        [SerializeField] private ScoreModel _scoreModel;
        [SerializeField] private ScoreView _scoreView;

        private void Awake()
        {
            _input.Init(_uiCamera);
            _level.Init(
                _mainCamera,
                _input,
                _skinContainer,
                _targetParametersContainer,
                _paddleParametersContainer,
                _paddleView1,
                _paddleView2,
                _scoreView);
        }
    }
}
