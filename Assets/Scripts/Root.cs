using UnityEngine;

namespace PingPong
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private MobileInput _input;
        [SerializeField] private PaddleView _paddleViewPrefab;
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Level _level;
        [SerializeField] private SkinContainer _skinContainer;
        [SerializeField] private TargetParametersContainer _targetParametersContainer;
        [SerializeField] private PaddleParametersContainer _paddleParametersContainer;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private SkinSelectorView _skinSelectorView;

        private void Awake()
        {
            _input.Init(_uiCamera);
            
            var skinSelectorModel = new SkinSelectorModel(_skinSelectorView, _skinContainer);
            _skinSelectorView.Ctor();

            var targetFactory = new TargetFactory(_skinContainer, skinSelectorModel, _targetParametersContainer);
            var paddleFactory = new PaddleFactory(_input, _mainCamera, _paddleParametersContainer, _paddleViewPrefab);

            var score = new ScoreModel();
            _scoreView.Ctor(score);

            _level.Ctor(targetFactory, paddleFactory, _mainCamera, score);

            GlobalStateMachine.Instance
                .AddState(new Play(_level))
                .AddState(new Customize(skinSelectorModel))
                .SetState<Play>();
        }

        private void OnApplicationQuit()
        {
            GameData.Instance.Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if(pause)
                GameData.Instance.Save();
        }
    }
}
