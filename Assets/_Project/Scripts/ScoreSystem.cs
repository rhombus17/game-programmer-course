using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static event System.Action<int> OnScoreChanged;
    static int _score;
    public static int Score => _score;

    public const string HighScoreKey = "HighScore";

    public static void Add(int points)
    {
        _score += points;
        OnScoreChanged?.Invoke(_score);
        
        int curHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (_score > curHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, _score);
        }
    }
}
