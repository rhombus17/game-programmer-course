using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public event System.Action OnPickedUp;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        // Collected
        gameObject.SetActive(false);
        OnPickedUp?.Invoke();
    }
}
