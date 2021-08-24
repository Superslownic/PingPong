using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class PaddleParametersContainer : ScriptableObject
    {
        [SerializeField] private PaddleParameters[] _parameters;

        public PaddleParameters Any()
        {
            return _parameters.Any();
        }
    }
}
