using System;
using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(TrailRenderer))]
    public class AdvancedThemeView : MonoBehaviour, ITargetView
    {
        [SerializeField] private ParticleSystem _particles;

        private SpriteRenderer _renderer;
        private TrailRenderer _trail;
        private Rigidbody2D _rigidbody;

        public event Action OnUpdate;
        public event Action<Collision2D> OnCollisionEnter;
        public event Action OnDestroyed;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _trail = GetComponent<TrailRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Setup(AdvancedTheme theme)
        {
            _renderer.sprite = theme.sprite;
            _renderer.color = theme.color;
            _trail.colorGradient = theme.trailColor;
            _trail.time = theme.trailLenght;
            ParticleSystem.MainModule main = _particles.main;
            main.startColor = theme.color;
            ParticleSystem.TrailModule trails = _particles.trails;
            trails.colorOverTrail = theme.color;
        }

        public void Move(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void Destroy()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            OnUpdate?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _particles.Play();
            OnCollisionEnter?.Invoke(collision);
        }
    }
}
