using UnityEngine;

public class UILockable : MonoBehaviour
{
    void OnEnable()
    {
        string levelName = GetComponent<UILevelLoadButton>().LevelName;
        string key = levelName + "Unlocked";
        int value = PlayerPrefs.GetInt(key, 0);
        if (value == 0)
        {
            gameObject.SetActive(false);
        }
    }

    [ContextMenu("Clear level flag")]
    void ClearFlag()
    {
        string levelName = GetComponent<UILevelLoadButton>().LevelName;
        string key = levelName + "Unlocked";
        PlayerPrefs.DeleteKey(key);
    }
}