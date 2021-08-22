using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PingPong
{
    public class GameData : Singleton<GameData>
    {
        private Dictionary<string, object> _data;

        public GameData()
        {
            try
            {
                _data = Serialization.LoadFromBinnary<Dictionary<string, object>>();
            }
            catch (FileNotFoundException)
            {
                _data = new Dictionary<string, object>();
            }
        }

        public void Save()
        {
            Serialization.SaveToBinnary(_data);
        }

        public void Set(string key, object value)
        {
            if (_data.ContainsKey(key))
                _data[key] = value;
            else
                _data.Add(key, value);
        }

        public T Get<T>(string key, T defaultValue)
        {
            try
            {
                return (T)_data[key];
            }
            catch (KeyNotFoundException)
            {
                return defaultValue;
            }
        }

#if UNITY_EDITOR
        [MenuItem("Settings/Clear save")]
        public static void Clear()
        {
            Serialization.DeleteBinnary();
        }
#endif
    }
}
