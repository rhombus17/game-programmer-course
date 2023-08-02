using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _levelLoadDelay = 1.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        // Play flag wave
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Raise");

        // Load new level
        StartCoroutine(LoadAfterDelay());        
    }

    IEnumerator LoadAfterDelay()
    {
        string key = _sceneName + "Unlocked";
        PlayerPrefs.SetInt(key, 1);
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(_sceneName);
    }
}
