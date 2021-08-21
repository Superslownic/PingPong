using UnityEngine;

namespace PingPong
{
    [RequireComponent(typeof(ParticleSystem))]
    public class AdvancedSkin : TargetView
    {
        private ParticleSystem _particles;
        
        protected override void LocalAwake()
        {
            _particles = GetComponent<ParticleSystem>();
        }

        protected override void LocalOnCollisionEnter(Collision2D collision)
        {
            _particles.Play();
        }
    }
}
