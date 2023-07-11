using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _levelLoadDelay = 1.5f;
    int completeStatus = 0;
    bool loadingNextLevel;

    void Start()
    {
        completeStatus = 0;
    }

    public void SetComplete(int playerNumber, bool complete)
    {
        if (loadingNextLevel)
            return;
        
        if (complete)
        {
            completeStatus += playerNumber;
            if (completeStatus >= 3)
            {
                Debug.Log("Level Complete");
                // Level is done.
                loadingNextLevel = true;
                // Stop input
                Player p = FindObjectOfType<Player>();
                p.DisablePlayer();
                // Play celebration animations or whatever
                FindObjectOfType<PlayerManager>().PlayWinCelebration();
                // Move on
                StartCoroutine(LoadAfterDelay());
            }
            
        }
        else
        {
            completeStatus -= playerNumber;
        }
    }
    
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(_sceneName);
    }
}
