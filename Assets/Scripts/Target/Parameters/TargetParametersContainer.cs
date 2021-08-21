using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class TargetParametersContainer : ScriptableObject
    {
        [SerializeField] private TargetParameters[] _parameters;

        public TargetParameters GetRandom()
        {
            return _parameters.Anyone();
        }
    }
}
