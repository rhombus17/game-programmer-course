using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatform : HittableFromBelow
{
    [SerializeField] float _resetTime;
    
    Collider2D _collider;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Use()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(_resetTime);
        _collider.enabled = true;
        _spriteRenderer.enabled = true;
    }
}
