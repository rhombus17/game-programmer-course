using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, ITakeDamage
{
    [SerializeField] Transform _sensorLeft;
    [SerializeField] Transform _sensorRight;
    [SerializeField] Sprite _deadSprite;
    Rigidbody2D _rigidbody2d;
    float _direction = -1f;
    bool _alive = true;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_alive)
            return;
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

        Vector2 normal = other.contacts[0].normal;

        if (normal.y <= -0.5f)
            Die();
        else
            player.ResetToStart();
    }

    void Die()
    {

        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        _alive = false;

        var audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
            audioSource.Play();

        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _deadSprite;
        StartCoroutine(FadeOutOverTime(spriteRenderer));
    }

    IEnumerator FadeOutOverTime(SpriteRenderer spriteRenderer)
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        Die();
    }
}
