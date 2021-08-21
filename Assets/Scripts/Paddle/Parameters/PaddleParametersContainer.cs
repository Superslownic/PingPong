using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class PaddleParametersContainer : ScriptableObject
    {
        [SerializeField] private PaddleParameters[] _parameters;

        public PaddleParameters GetRandom()
        {
            return _parameters.Anyone();
        }
    }
}
