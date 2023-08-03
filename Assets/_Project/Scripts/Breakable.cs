using UnityEngine;

public class Breakable : MonoBehaviour, ITakeDamage
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Player>() == null)
            return;
        
        if (other.contacts[0].normal.y > 0)
        {
            TakeHit();
        }
    }

    void TakeHit()
    {
        var particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void TakeDamage()
    {
        TakeHit();
    }
}
