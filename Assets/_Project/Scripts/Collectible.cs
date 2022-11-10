using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    List<Collector> _collectors = new List<Collector>();

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        // Collected
        gameObject.SetActive(false);
        foreach (var collector in _collectors)
        {
            collector.MarkCollected();
        }
    }

    public void AddCollector(Collector collector)
    {
        _collectors.Add(collector);
    }
}
