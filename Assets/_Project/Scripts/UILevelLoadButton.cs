using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelLoadButton : MonoBehaviour
{
    [SerializeField] string _levelToLoad;
    public string LevelName => _levelToLoad;

    public void LoadLevel()
    {
        ScoreSystem.ResetScore();
        SceneManager.LoadScene(_levelToLoad);
    }
}