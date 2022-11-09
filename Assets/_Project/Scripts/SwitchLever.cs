using UnityEngine;
using UnityEngine.Events;

public class SwitchLever : MonoBehaviour
{
    [SerializeField] Sprite _switchedSprite;
    [SerializeField] UnityEvent _onPressed;

    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        GetSwitched();
    }

    void GetSwitched()
    {
        _spriteRenderer.sprite = _switchedSprite;
        _onPressed?.Invoke();
    }
}
