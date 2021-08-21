using System;
using UnityEngine;

namespace PingPong
{
    public interface IInput
    {
        event Action<float> OnPointerDown;
        event Action<float> OnDrag;
    }
}