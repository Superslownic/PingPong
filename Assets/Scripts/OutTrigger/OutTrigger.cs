using System;
using UnityEngine;

namespace PingPong
{
    public class OutTrigger : MonoBehaviour
    {
        public event Action OnOut;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.HasComponent<ITarget>())
                OnOut?.Invoke();
        }
    }
}
