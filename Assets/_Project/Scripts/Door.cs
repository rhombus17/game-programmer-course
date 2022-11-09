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
    [SerializeField] Transform _exit;
    [SerializeField] Canvas _canvas;
    
    bool _open;

    void Update()
    {
        if (!_open && Coin.CoinsCollected >= _requiredCoins)
        {
            Open();
        }
    }

    void Open()
    {
        _open = true;
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
        if (_canvas != null)
            _canvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_open || _exit == null)
        {
            return;
        }

        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TeleportTo(_exit.position);
        }
    }
}
