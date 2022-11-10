using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Sprite _emptyBoxSprite;
    [SerializeField] Vector2 _itemLaunchVelocity;

    bool _used;

    void Start()
    {
        if (_item != null)
            _item.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (_used)
            return;
        
        var player = col.collider.GetComponent<Player>();
        if (player == null)
            return;
        
        if (col.contacts[0].normal.y <= 0)
            return;

        _used = true;
        GetComponent<SpriteRenderer>().sprite = _emptyBoxSprite;
        if (_item == null)
            return;
        _item.SetActive(true);
        
        var itemRigidbody = _item.GetComponent<Rigidbody2D>();
        if (itemRigidbody == null)
            return;
        itemRigidbody.velocity = _itemLaunchVelocity;
    }
}
