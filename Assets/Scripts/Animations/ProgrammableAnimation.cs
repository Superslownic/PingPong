using System;
using System.Collections;
using UnityEngine;

public class ProgrammableAnimation
{
    private Coroutine _lastAnimation;
    private MonoBehaviour _context;

    public ProgrammableAnimation(MonoBehaviour context)
    {
        _context = context;
    }

    public void Play(float duration, Action<float> action, Action callback)
    {
        if (_lastAnimation != null)
            _context.StopCoroutine(_lastAnimation);

        _lastAnimation = _context.StartCoroutine(CreateAnimation(duration, action, callback));
    }

    private IEnumerator CreateAnimation(float duration, Action<float> action, Action callback)
    {
        float expiredSeconds = 0;
        float progress = 0;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;
            action.Invoke(progress);
            yield return null;
        }

        callback?.Invoke();
    }
}
