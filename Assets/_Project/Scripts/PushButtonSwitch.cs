using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite _depressedSprite;
    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;

    SpriteRenderer _spriteRenderer;
    Sprite _releasedSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;
        BecomeReleased();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;

        BecomePressed();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        BecomeReleased();
    }

    void BecomePressed()
    {
        _spriteRenderer.sprite = _depressedSprite;
        _onPressed?.Invoke();
    }

    void BecomeReleased()
    {
        _spriteRenderer.sprite = _releasedSprite;
        _onReleased?.Invoke();
    }
}
