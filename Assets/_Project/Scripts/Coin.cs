using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinsCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;

        gameObject.SetActive(false);
        CoinsCollected++;

        ScoreSystem.Add(100);
    }
}
