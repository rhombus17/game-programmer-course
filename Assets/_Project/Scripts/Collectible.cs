using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    Collector _collector;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        // Collected
        gameObject.SetActive(false);
        _collector.MarkCollected();
    }

    public void SetCollector(Collector collector)
    {
        _collector = collector;
    }
}
