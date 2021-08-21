using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _index;

    public void Load()
    {
        SceneManager.LoadScene(_index);
    }
}
