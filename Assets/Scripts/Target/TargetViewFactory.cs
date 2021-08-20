using UnityEngine;

namespace PingPong
{
    public class TargetViewFactory
    {
        public T Create<T>() where T : Object, ITargetView
        {
            var prefab = Resources.Load<T>("View/Target/" + typeof(T).Name);
            return Object.Instantiate(prefab);
        }
    }
}
