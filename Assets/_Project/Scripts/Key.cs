using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] KeyLock _keyLock;

    void OnTriggerEnter2D(Collider2D other)
    {
        bool lockCollision = CheckLockCollision(other);
        if (lockCollision)
            return;
        
        bool playerCollision = CheckPlayerCollision(other);
        if (playerCollision)
            return;
    }

    bool CheckPlayerCollision(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return false;

        transform.SetParent(player.transform);
        transform.localPosition = Vector3.up;
        return true;
    }

    bool CheckLockCollision(Collider2D other)
    {
        if (_keyLock == null)
            return false;
        
        KeyLock keyLock = other.GetComponent<KeyLock>();
        if (keyLock == null || keyLock != _keyLock)
            return false;

        keyLock.Unlock();
        Destroy(gameObject);
        return true;
    }
}
