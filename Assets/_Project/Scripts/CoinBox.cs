using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] int _totalCoins = 3;
    [SerializeField] Sprite _emptyBoxSprite;

    int _remainingCoins;

    void Start()
    {
        _remainingCoins = _totalCoins;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.collider.GetComponent<Player>();
        if (player == null)
            return;

        if (col.contacts[0].normal.y <= 0 || _remainingCoins <= 0)
            return;
        
        _remainingCoins--;
        Coin.CoinsCollected++;

        if (_remainingCoins <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = _emptyBoxSprite;
        }
    }
}
