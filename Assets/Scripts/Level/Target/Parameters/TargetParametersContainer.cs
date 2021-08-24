using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class TargetParametersContainer : ScriptableObject
    {
        [SerializeField] private TargetParameters[] _parameters;

        public TargetParameters Any()
        {
            return _parameters.Any();
        }
    }
}
