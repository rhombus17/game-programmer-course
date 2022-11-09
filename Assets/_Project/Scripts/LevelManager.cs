using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _levelLoadDelay = 1.5f;
    int completeStatus = 0;

    void Start()
    {
        completeStatus = 0;
    }

    public void SetComplete(int playerNumber, bool complete)
    {
        if (complete)
        {
            completeStatus += playerNumber;
            if (completeStatus >= 3)
            {
                Debug.Log("Level Complete");
                // Level is done.
                // Stop input
                // Play celebration animations or whatever
                // Move on
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
