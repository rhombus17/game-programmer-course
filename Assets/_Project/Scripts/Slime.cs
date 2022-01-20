using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Transform _sensorLeft;
    [SerializeField] Transform _sensorRight;
    Rigidbody2D _rigidbody2d;
    float _direction = -1f;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var desiredVelocity = new Vector2(-1, _rigidbody2d.velocity.y);
        _rigidbody2d.velocity = desiredVelocity;
        Transform sensor = _direction > 0 ? _sensorLeft : _sensorLeft;

        Debug.DrawRay(sensor.position, Vector2.down * 0.1f, Color.red);
        var result = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
        {
            TurnAround();
        }
    }

    void TurnAround()
    {
        _direction *= -1;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = _direction > 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player == null)
            return;

        player.ResetToStart();
    }
}
