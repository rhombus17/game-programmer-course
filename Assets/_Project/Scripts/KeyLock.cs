using UnityEngine;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [SerializeField] UnityEvent _onUnlocked;

    public void Unlock()
    {
        Debug.Log($"Unlock");
        _onUnlocked?.Invoke();
    }
}
