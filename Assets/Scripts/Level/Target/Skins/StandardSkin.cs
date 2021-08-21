using UnityEngine;

namespace PingPong
{
    public class StandardSkin : TargetView
    {
        protected override void ForwardedAwake() {}
        protected override void ForwardedOnCollisionEnter(Collision2D collision) { }
        protected override void ForwardedReset() { }
    }
}
