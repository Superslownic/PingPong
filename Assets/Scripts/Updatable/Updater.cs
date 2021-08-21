using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class Updater : MonoSingleton<Updater>
    {
        private List<Updatable> _updatables;

        private List<Updatable> Updatables
        {
            get
            {
                if (_updatables == null)
                    _updatables = new List<Updatable>();

                return _updatables;
            }
        }

        public void Subscribe(Updatable updatable)
        {
            Updatables.Add(updatable);
        }

        public void Unsubscribe(Updatable updatable)
        {
            Updatables.Remove(updatable);
        }

        private void Update()
        {
            for (int i = 0; i < _updatables.Count; i++)
                _updatables[i].OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _updatables.Count; i++)
                _updatables[i].OnFixedUpdate(Time.fixedDeltaTime);
        }
    }
}
