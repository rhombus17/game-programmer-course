using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;


public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _maxJumps = 2;
    [SerializeField] float _jumpForce = 200f;

    Vector2 _startPosition;
    int _jumpsRemaining;

    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
    }

    void Update()
    {
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

        if (Input.GetButtonDown("Fire1") && _jumpsRemaining > 0)
        {
            rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _jumpsRemaining--;
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        _jumpsRemaining = _maxJumps;
    }

    public void ResetToStart()
    {
        transform.position = _startPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
