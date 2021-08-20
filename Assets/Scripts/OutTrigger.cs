using UnityEngine;

namespace PingPong
{
    public class OutTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.HasComponent(out IResettable obj))
                obj.Reset();
        }
    }
}
