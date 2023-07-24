using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelLoadButton : MonoBehaviour
{
    [SerializeField] string _levelToLoad;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
