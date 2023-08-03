using UnityEngine;

public class ResetOnEnter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    { 
        var player = collision.collider.GetComponent<Player>();
         if (player == null)
             return;
         player.ResetToStart();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (player == null)
            return;
        player.ResetToStart();
    }

    void OnParticleCollision(GameObject other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;
        player.ResetToStart();
    }
}
