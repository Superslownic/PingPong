using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class ParametersContainer : ScriptableObject
    {
        [SerializeField] private TargetParameters[] _skins;

        public TargetParameters GetRandom()
        {
            return _skins.Anyone();
        }
    }
}
