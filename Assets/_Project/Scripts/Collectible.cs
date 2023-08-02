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
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        OnPickedUp?.Invoke();
        
        GetComponent<AudioSource>().Play();
    }
}
