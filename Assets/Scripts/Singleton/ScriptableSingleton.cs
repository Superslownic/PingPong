using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
{
    protected static readonly string assetName = "Settings/" + typeof(T).Name;
#if UNITY_EDITOR
    protected static readonly string assetFolder = "Resources/Settings";
    protected static readonly string assetFile = typeof(T).Name + ".asset";
#endif

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load(assetName) as T;
                if (_instance == null)
                {
                    // If not found, autocreate the asset object.
                    _instance = CreateInstance<T>();
                    _instance.OnCreated();
#if UNITY_EDITOR
                    MakeFolderOnAssets(assetFolder);
                    string fullPath = Path.Combine(Path.Combine("Assets", assetFolder), assetFile);
                    AssetDatabase.CreateAsset(_instance, fullPath);
#endif
                }
            }
            return _instance;
        }
    }
    protected abstract void OnCreated();

#if UNITY_EDITOR
    private static void MakeFolderOnAssets(string path)
    {
        string[] folderNames = path.Split('/');
        string currentPath = "Assets";
        for (int i = 0; i < folderNames.Length; i++)
        {
            string folderPath = Path.Combine(currentPath, folderNames[i]);
            if (!Directory.Exists(folderPath))
            {
                AssetDatabase.CreateFolder(currentPath, folderNames[i]);
            }
            currentPath = folderPath;
        }
    }
#endif
}