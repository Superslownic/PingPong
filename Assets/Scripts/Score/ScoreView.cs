using TMPro;
using UnityEngine;

namespace PingPong
{
    public class ScoreView : MonoBehaviour, IContructable<ScoreModel>
    {
        [SerializeField] private TextMeshPro _currentScore;
        [SerializeField] private TextMeshPro _bestScore;

        private ScoreModel _model;

        public void Ctor(ScoreModel model)
        {
            _model = model;
            _model.OnCurrentScoreChanged += UpdateCurrentScore;
            _model.OnBestScoreChanged += UpdateBestScore;
        }

        private void OnDestroy()
        {
            _model.OnCurrentScoreChanged -= UpdateCurrentScore;
            _model.OnBestScoreChanged -= UpdateBestScore;
        }

        public void UpdateCurrentScore(int value)
        {
            _currentScore.text = value.ToString();
        }

        public void UpdateBestScore(int value)
        {
            _bestScore.text = value.ToString();
        }
    }
}
