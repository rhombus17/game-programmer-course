using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] ToggleState _startingState = ToggleState.Middle;
    [SerializeField] Sprite _leftToggleSprite;
    [SerializeField] Sprite _rightToggleSprite;
    [SerializeField] Sprite _middleToggleSprite;
    [SerializeField] UnityEvent _onLeftToggle;
    [SerializeField] UnityEvent _onRightToggle;
    [SerializeField] UnityEvent _onMiddleToggle;
    [SerializeField] float _deadZone = 0.5f;

    [SerializeField] AudioClip _leftSound;
    [SerializeField] AudioClip _rightSound;

    ToggleState _toggleState;
    SpriteRenderer _spriteRenderer;
    AudioSource _audioSource;
    float _xPosition;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _xPosition = transform.position.x;
        Toggle(_startingState);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;

        float playerX = player.transform.position.x;
        if (Mathf.Abs(playerX - _xPosition) < _deadZone)
            return;
        
        if (playerX > _xPosition)
            ToggleRight();
        else
            ToggleLeft();
        
    }

    void ToggleRight() => Toggle(ToggleState.Right);

    void ToggleLeft() => Toggle(ToggleState.Left);

    void Toggle(ToggleState newState, bool force = false)
    {
        if (!force && _toggleState == newState)
            return;

        _toggleState = newState;

        switch (newState)
        {
            case ToggleState.Left:
                _spriteRenderer.sprite = _leftToggleSprite;
                _onLeftToggle.Invoke();
                if (_audioSource != null)
                    _audioSource.PlayOneShot(_leftSound);
                break;
            case ToggleState.Middle:
                _spriteRenderer.sprite = _middleToggleSprite;
                _onMiddleToggle.Invoke();
                break;
            case ToggleState.Right:
                _spriteRenderer.sprite = _rightToggleSprite;
                _onRightToggle.Invoke();
                if (_audioSource != null)
                    _audioSource.PlayOneShot(_rightSound);
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    void OnValidate()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        
        switch (_startingState)
        {
            case ToggleState.Left:
                renderer.sprite = _leftToggleSprite;
                break;
            case ToggleState.Middle:
                renderer.sprite = _middleToggleSprite;
                break;
            case ToggleState.Right:
                renderer.sprite = _rightToggleSprite;
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
    }

    enum ToggleState
    {
        Left,
        Middle,
        Right
    }
}
