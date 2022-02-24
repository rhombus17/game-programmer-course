using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite _openMid;
    [SerializeField] Sprite _openTop;
    [SerializeField] SpriteRenderer _rendererMid;
    [SerializeField] SpriteRenderer _rendererTop;
    [SerializeField] int _requiredCoins = 5;
    [SerializeField] Door _exit;

    void Update()
    {
        if (Coin.CoinsCollected >= _requiredCoins)
        {
            Open();
        }
    }

    void Open()
    {
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && _exit != null)
        {
            player.TeleportTo(_exit.transform.position);
        }
    }
}
