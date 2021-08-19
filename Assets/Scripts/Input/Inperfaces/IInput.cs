using UnityEngine;

namespace PingPong
{
    public interface IInput
    {
        Vector3 TouchPosition { get; }
    }
}