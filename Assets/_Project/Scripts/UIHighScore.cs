using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHighScore : MonoBehaviour
{
    TMP_Text _highScoreText;

    void OnEnable()
    {
        _highScoreText = GetComponent<TMP_Text>();
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        _highScoreText.SetText(highScore.ToString());
    }

    [ContextMenu("Reset High Score")]
    void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(ScoreSystem.HighScoreKey);
    }
}
