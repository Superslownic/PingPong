using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector3 _from;
    [SerializeField] private Vector3 _to;
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
        result += Vector3.Lerp(_from, _to, _curve.Evaluate(progress));
        transform.localPosition = result;
    }
}
