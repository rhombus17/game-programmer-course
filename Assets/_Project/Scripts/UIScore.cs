using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIScore : MonoBehaviour
{
    TMP_Text _scoreText;

    void OnEnable()
    {
        _scoreText = GetComponent<TMP_Text>();
        UpdateScore(ScoreSystem.Score);
        ScoreSystem.OnScoreChanged += UpdateScore;
    }

    void OnDestroy()
    {
        ScoreSystem.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}
