using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] float _bounceVelocity = 10f;

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player == null)
            return;
        
        var rigidbody2D = player.GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
        {
            Debug.LogError("Player does not have a rigidBody");
            return;
        }

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _bounceVelocity);
    }
}
