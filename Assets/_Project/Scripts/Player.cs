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

    Vector2 _startPosition;
    int _jumpsRemaining;
    float _fallTimer;
    float _jumpTimer = 0f;

    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
    }

    void Update()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, 0.1f, LayerMask.GetMask("Default"));
        bool isGrounded = hit != null;

        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(horizontal) >= 1)
        {
            rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
        }

        var animator = GetComponent<Animator>();
        bool walking = horizontal != 0;
        animator.SetBool("Walk", walking);

        if (horizontal != 0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }

        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && _jumpsRemaining > 0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpVelocity);
            _jumpsRemaining--;
            _jumpTimer = 0f;
            _fallTimer = 0f;
        }
        else if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && _jumpTimer <= _maxJumpDuration)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpVelocity);
            _fallTimer = 0f;
        }

        _jumpTimer += Time.deltaTime;
        
        if (isGrounded && _fallTimer > 0)
        {
            _jumpsRemaining = _maxJumps;
            _fallTimer = 0f;
        }
        else
        {
            _fallTimer += Time.deltaTime;
            var downForce = _downPull * _fallTimer * _fallTimer;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y - downForce);
        }
    }

    public void ResetToStart()
    {
        transform.position = _startPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
