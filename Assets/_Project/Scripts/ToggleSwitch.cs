using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] Sprite _leftToggleSprite;
    [SerializeField] Sprite _rightToggleSprite;
    [SerializeField] UnityEvent _onLeftToggle;
    [SerializeField] UnityEvent _onRightToggle;
    [SerializeField] float _deadZone = 0.5f;

    ToggleState _toggleState;
    SpriteRenderer _spriteRenderer;
    float _xPosition;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _xPosition = transform.position.x;
        _toggleState = ToggleState.Middle;
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

    void ToggleRight()
    {
        if (_toggleState == ToggleState.Right)
            return;

        _toggleState = ToggleState.Right;
        _spriteRenderer.sprite = _rightToggleSprite;
        _onRightToggle.Invoke();
    }

    void ToggleLeft()
    {
        if (_toggleState == ToggleState.Left)
            return;

        _toggleState = ToggleState.Left;
        _spriteRenderer.sprite = _leftToggleSprite;
        _onLeftToggle.Invoke();
    }

    enum ToggleState
    {
        Left,
        Middle,
        Right
    }
}
