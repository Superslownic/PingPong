using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PingPong
{
    public class Serialization : MonoBehaviour
    {
        private static string Path => System.IO.Path.Combine(Application.persistentDataPath, "PingPong.save");

        public static void SaveToBinnary<T>(T SerializableObject)
        {
            using (FileStream fs = File.Create(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, SerializableObject);
            }
        }

        public static T LoadFromBinnary<T>()
        {
            using (FileStream fs = File.Open(Path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(fs);
            }
        }

        public static void DeleteBinnary()
        {
            File.Delete(Path);
        }
    } 
}
