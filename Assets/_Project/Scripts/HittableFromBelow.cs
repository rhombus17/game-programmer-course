using System;
using UnityEngine;

public abstract class HittableFromBelow : MonoBehaviour
{
    [SerializeField] protected Sprite _emptyBoxSprite;
    Animator _animator;
    protected AudioSource _audioSource;
    
    static readonly int UseHashID = Animator.StringToHash("Use");

    protected virtual bool CanUse => true;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!CanUse)
            return;
        
        var player = col.collider.GetComponent<Player>();
        if (player == null)
            return;
        
        if (col.contacts[0].normal.y <= 0)
            return;

        PlayAnimation();
        Use();
        if (!CanUse)
            GetComponent<SpriteRenderer>().sprite = _emptyBoxSprite;
    }

    void PlayAnimation()
    {
        if (_animator != null)
            _animator.SetTrigger(UseHashID);
    }

    protected abstract void Use();
}
