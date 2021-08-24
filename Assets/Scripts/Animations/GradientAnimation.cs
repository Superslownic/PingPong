using UnityEngine;

public class GradientAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _target;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private bool _playOnEnable;
    [SerializeField] private bool _loop;
    [SerializeField] private float _duration;

    private ProgrammableAnimation _animation;
    
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
        if(_loop)
            _animation.Play(_duration, Process, Play);
        else
            _animation.Play(_duration, Process, null);
    }

    private void Process(float progress)
    {
        _target.color = _gradient.Evaluate(progress);
    }
}
