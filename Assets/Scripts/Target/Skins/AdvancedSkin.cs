using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(ParticleSystem))]
    [RequireComponent(typeof(TrailRenderer))]
    public class AdvancedSkin : TargetView
    {
        private ParticleSystem _particles;
        private TrailRenderer _trail;
        
        protected override void ForwardedAwake()
        {
            _particles = GetComponent<ParticleSystem>();
            _trail = GetComponent<TrailRenderer>();
        }

        protected override void ForwardedOnCollisionEnter(Collision2D collision)
        {
            _particles.Play();
        }

        protected override void ForwardedReset()
        {
            _trail.Clear();
        }
    }
}
