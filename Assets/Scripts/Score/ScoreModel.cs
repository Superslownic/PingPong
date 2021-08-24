using System;

namespace PingPong
{
    public class ScoreModel
    {
        private int _currentScore;
        private int _bestScore;
        
        public ScoreModel()
        {
            BestScore = GameData.Instance.Get("BestScore", 0);
            CurrentScore = 0;
        }

        public event Action<int> OnCurrentScoreChanged;
        public event Action<int> OnBestScoreChanged;

        private int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                OnCurrentScoreChanged?.Invoke(value);
            }
        }

        private int BestScore
        {
            get => _bestScore;
            set
            {
                _bestScore = value;
                OnBestScoreChanged?.Invoke(value);
            }
        }

        public void AddScore()
        {
            CurrentScore += 1;
        }

        public void ResetScore()
        {
            BestScore = _currentScore > _bestScore ? _currentScore : _bestScore;
            CurrentScore = 0;
            GameData.Instance.Set("BestScore", BestScore);
        }
    }
}
