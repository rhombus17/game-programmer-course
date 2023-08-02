using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
