using UnityEngine;

public class Breakable : MonoBehaviour
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
        gameObject.SetActive(false);
    }
}
