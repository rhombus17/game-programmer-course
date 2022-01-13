using System.Collections;
using System.Collections.Generic;
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
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(_sceneName);
    }
}
