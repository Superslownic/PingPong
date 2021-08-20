using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace PingPong
{
    public class ThemeContainer : MonoBehaviour
    {
        [SerializeField] private Theme[] _themes;
        
        public Theme GetRandomTheme()
        {
            return _themes.Anyone();
        }

        public T GetRandomTheme<T>() where T : Theme
        {
            return (T)_themes.Where(t => t.GetType() == typeof(T)).Anyone();
        }

        
    }
}
