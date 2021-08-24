using System;

namespace PingPong
{
    public abstract class Updatable
    {
        public Updatable()
        {
            Updater.Instance.Subscribe(this);
        }

        public virtual void OnUpdate(float delta) { }
        public virtual void OnFixedUpdate(float delta) { }
        
        ~Updatable()
        {
            Updater.Instance.Unsubscribe(this);
        }
    }
}
