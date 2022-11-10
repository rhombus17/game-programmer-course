using System;
using TutInput;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [Range(1,2)]
    [SerializeField] int _playerNumber = 1;
    [Header("Reference")]
    [SerializeField] Transform _feet;
    [Header("Movement")]
    [SerializeField] float _speed = 5f;
    [SerializeField] float _slipFactor = 1f;
    [Header("Jump")]
    [SerializeField] int _maxJumps = 2;
    [SerializeField] float _jumpVelocity = 8f;
    [SerializeField] float _downPull = 2f;
    [SerializeField] float _maxJumpDuration = 5f;

    public int PlayerNumber => _playerNumber;

    Rigidbody2D _rigidbody2D;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Vector2 _startPosition;
    bool _isGrounded;
    bool _isGroundSlippery;
    int _jumpsRemaining;
    float _fallTimer;
    float _jumpTimer = 0f;
    float _horizontal;
    int _groundLayerMask;
    bool _flipX;

    bool _jumpCued = false;
    bool _jumpHeld = false;

    InputActions _input;
    static readonly int JumpHash = Animator.StringToHash("Jump");
    static readonly int Walk = Animator.StringToHash("Walk");

    void Awake()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _isGroundSlippery = true;
        _groundLayerMask = LayerMask.GetMask("Default");

        if (FindObjectOfType<PlayerManager>().multiInput)
            Setup2PInput();
        else
            Setup1PInput();
    }

    void Setup2PInput()
    {
        InputActions inputAction = new TutInput.InputActions();

        // inputAction._2DControl.Enable();
        InputAction move;// = inputAction._2DControl.Move;
        InputAction jump;// = inputAction._2DControl.Jump;

        switch(_playerNumber)
        {
            case 1:
            default:
                inputAction.P1.Enable();
                move = inputAction.P1.Move;
                jump = inputAction.P1.Jump;
                break;
            case 2:
                inputAction.P2.Enable();
                move = inputAction.P2.Move;
                jump = inputAction.P2.Jump;
                break;
        }

        move.performed += MoveInput;
        move.canceled += MoveInput;
        jump.started += JumpInput;
        jump.performed += JumpInput;
    }

    public void EnablePlayer()
    {
        if (_input != null)
            _input.Enable();
    }

    public void DisablePlayer()
    {
        if (_input != null)
            _input.Disable();
    }

    void Setup1PInput()
    {
        _input = new InputActions();
        // inputActions.Enable();

        _input.P1.Move.performed += MoveInput;
        _input.P1.Move.canceled += MoveInput;
        _input.P1.Jump.started += JumpInput;
        _input.P1.Jump.performed += JumpInput;
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        _horizontal = ctx.ReadValue<float>();
    }

    public void JumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _jumpCued = true;
        }
        _jumpHeld = ctx.performed;
    }
    
    public void SwitchInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;
        
        _playerNumber = _playerNumber == 1 ? 2 : 1;
    }

    void Update()
    {
        UpdateIsGrounded();

        if (_isGroundSlippery)
            SlipHorizontal();
        else
            MoveHorizontal();

        // UpdateAnimator();
        // UpdateSpriteDirection();
        // Debug.Log($"Check 3: {_spriteRenderer.flipX}");
        

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

    void LateUpdate()
    {
        UpdateSpriteDirection();
        UpdateAnimator();
    }

    void UpdateIsGrounded()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, 0.1f, _groundLayerMask);
        _isGrounded = hit != null;

        if (hit != null)
            _isGroundSlippery = hit.CompareTag("Slippery");
    }

    void MoveHorizontal()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
    }

    void SlipHorizontal()
    {
        var targetVelocity = new Vector2(_horizontal * _speed, _rigidbody2D.velocity.y);
        var smoothedVelocity = Vector2.Lerp(
            _rigidbody2D.velocity,
            targetVelocity,
            Time.deltaTime / _slipFactor);

        _rigidbody2D.velocity = smoothedVelocity;
    }

    void UpdateAnimator()
    {
        bool walking = _horizontal != 0;
        _animator.SetBool(Walk, walking);
        bool jumping = ShouldContinueJump();
        _animator.SetBool(JumpHash, !_isGrounded || jumping);
    }

    void UpdateSpriteDirection()
    {
        if (_horizontal != 0)
        {
            _flipX = _horizontal < 0;
        }

        _spriteRenderer.flipX = _flipX;
    }

    bool ShouldStartJump()
    {
        bool shouldJump = _jumpCued && _jumpsRemaining > 0;
        _jumpCued = false;
        return shouldJump;
    }

    bool ShouldContinueJump()
    {
        return (_jumpHeld && _jumpTimer <= _maxJumpDuration);
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
        TeleportTo(_startPosition);
    }

    public void TeleportTo(Vector3 teleportPosition)
    {
        _rigidbody2D.position = teleportPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
