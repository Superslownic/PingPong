using System;
using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu]
    public class SkinContainer : ScriptableObject
    {
        [SerializeField] private Skin[] _skins;

        public int Count => _skins.Length;

        public Skin ElementAt(int index)
        {
            if (index < 0 || index > _skins.Length - 1)
                throw new ArgumentOutOfRangeException();

            return _skins[index];
        }

        public Skin AnySkin()
        {
            return _skins.Any();
        }
    }
}
