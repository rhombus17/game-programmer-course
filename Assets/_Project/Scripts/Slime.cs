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
        MoveSlime();
        ScanSensors();
    }

    void MoveSlime()
    {
        var desiredVelocity = new Vector2(1, _rigidbody2d.velocity.y) * _direction;
        _rigidbody2d.velocity = desiredVelocity;
    }

    void ScanSensors()
    {
        Transform sensor = _direction > 0 ? _sensorRight : _sensorLeft;
        var turnBcDown = ScanSensor(sensor, Vector2.down, true);
        var turnBcFwd = ScanSensor(sensor, new Vector2(_direction, 0), false);
        if (turnBcDown || turnBcFwd)
        {
            TurnAround();
        }
    }

    bool ScanSensor(Transform sensor, Vector2 scanDirection, bool checkForEmpty)
    {
        scanDirection = scanDirection.normalized;
        Debug.DrawRay(sensor.position, scanDirection * 0.1f, Color.red);
        var result = Physics2D.Raycast(sensor.position, scanDirection, 0.1f);
        return checkForEmpty ? result.collider == null : result.collider != null;
        // if (result.collider == null)
        // {
        //     TurnAround();
        // }
        // var sideResult = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f);
        // if (sideResult.collider != null)
        // {
        //     TurnAround();
        // }
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
