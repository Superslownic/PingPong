using System;
using UnityEngine;

namespace PingPong
{
    public interface ITargetView
    {
        event Action<float> OnUpdate;
        event Action<Collision2D> OnCollisionEnter;
        event Action OnDestroyed;
        void Move(Vector2 velocity);
        void SetPosition(Vector2 position);
        void SetSize(Vector3 size);
        void Destroy();
    }
}
