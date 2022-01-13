using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;


public class Player : MonoBehaviour
{
    [SerializeField] Transform _feet;
    [SerializeField] float _speed = 5f;
    [SerializeField] int _maxJumps = 2;
    [SerializeField] float _jumpVelocity = 8f;
    [SerializeField] float _downPull = 2f;
    [SerializeField] float _maxJumpDuration = 5f;

    Rigidbody2D _rigidbody2D;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Vector2 _startPosition;
    bool _isGrounded;
    int _jumpsRemaining;
    float _fallTimer;
    float _jumpTimer = 0f;
    float _horizontal;

    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateIsGrounded();
        ReadHorizontalInput();
        MoveHorizontal();


        UpdateAnimator();
        UpdateSpriteDirection();


        if (ShouldStartJump())
            Jump();
        else if (ShouldContinueJump())
            ContinueJump();

        _jumpTimer += Time.deltaTime;

        if (_isGrounded && _fallTimer > 0)
        {
            _jumpsRemaining = _maxJumps;
            _fallTimer = 0f;
        }
        else
        {
            _fallTimer += Time.deltaTime;
            var downForce = _downPull * _fallTimer * _fallTimer;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - downForce);
        }
    }

    void UpdateIsGrounded()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, 0.1f, LayerMask.GetMask("Default"));
        _isGrounded = hit != null;
    }

    void ReadHorizontalInput()
    {
        _horizontal = Input.GetAxis("Horizontal") * _speed;
    }

    void MoveHorizontal()
    {
        if (Mathf.Abs(_horizontal) >= 1)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal, _rigidbody2D.velocity.y);
        }
    }

    void UpdateAnimator()
    {
        bool walking = _horizontal != 0;
        _animator.SetBool("Walk", walking);
    }

    void UpdateSpriteDirection()
    {
        if (_horizontal != 0)
        {
            _spriteRenderer.flipX = _horizontal < 0;
        }
    }

    bool ShouldStartJump()
    {
        return (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && _jumpsRemaining > 0;
    }

    bool ShouldContinueJump()
    {
        return (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && _jumpTimer <= _maxJumpDuration;
    }

    void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _jumpsRemaining--;
        _jumpTimer = 0f;
        _fallTimer = 0f;
    }

    void ContinueJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _fallTimer = 0f;
    }

    public void ResetToStart()
    {
        transform.position = _startPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
