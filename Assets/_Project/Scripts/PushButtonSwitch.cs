using UnityEngine;
using UnityEngine.Events;

public class PushButtonSwitch : MonoBehaviour
{
    [SerializeField] Sprite _depressedSprite;
    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;
    [SerializeField] int _playerNumber;

    SpriteRenderer _spriteRenderer;
    Sprite _releasedSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;
    }

    void Start()
    {
        BecomeReleased();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
            return;

        BecomePressed();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player == null || player.PlayerNumber != _playerNumber)
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
