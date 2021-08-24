using TMPro;
using UnityEngine;

namespace PingPong
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _bestScore;

        private ScoreModel _model;

        public ScoreView Ctor(ScoreModel model)
        {
            _model = model;
            _model.OnCurrentScoreChanged += UpdateCurrentScore;
            _model.OnBestScoreChanged += UpdateBestScore;

            return this;
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
