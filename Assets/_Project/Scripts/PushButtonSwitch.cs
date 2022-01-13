using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite _downSprite;
    [SerializeField] UnityEvent _onEnter;

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _downSprite;
        _onEnter?.Invoke();
    }
}
