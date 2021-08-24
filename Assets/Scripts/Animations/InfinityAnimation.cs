using UnityEngine;

namespace CrowdRace
{
    public class InfinityAnimation : MonoBehaviour
    {
        [SerializeField] private Vector2 _amplitude;
        [SerializeField] private Vector2 _frequency;
        [SerializeField] private bool _playOnEnable;
        [SerializeField] private bool _loop;
        [SerializeField] private float _duration;

        private ProgrammableAnimation _animation;
        private Vector3 _startPosition;

        private void Awake()
        {
            _animation = new ProgrammableAnimation(this);
        }

        private void OnEnable()
        {
            if (_playOnEnable)
                Play();
        }

        public void Play()
        {
            _startPosition = transform.localPosition;

            if (_loop)
                _animation.Play(_duration, Process, Play);
            else
                _animation.Play(_duration, Process, null);
        }

        private void Process(float progress)
        {
            Vector3 result = _startPosition;
            result.x += _amplitude.x * Mathf.Sin(progress * 2 * Mathf.PI * _frequency.x);
            result.y += _amplitude.y * Mathf.Sin(progress * 2 * Mathf.PI * _frequency.y);
            transform.localPosition = result;
        }
    }
}
