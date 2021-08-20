using UnityEngine;

namespace PingPong
{
    public interface ITargetModel
    {
        void Stop();
        void SetPosition(Vector2 position);
        void Push(Vector2 direction);
        //void Setup(Parameters parameters);
        void SetTheme(Theme theme);
    }
}
