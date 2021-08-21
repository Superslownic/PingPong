using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class SkinContainer : ScriptableObject
    {
        [SerializeField] private TargetView[] _skins;
        
        public TargetView GetRandom()
        {
            return _skins.Anyone();
        }
    }
}
