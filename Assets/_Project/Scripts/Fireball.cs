using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] int _numBounces = 3;
    [SerializeField] float _horizontalVelocity = 5f;
    [SerializeField] float _bounceForce = 5f;


    Rigidbody2D _rigidbody;
    int _bouncesRemaining;
    int _direction;

    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _bouncesRemaining = _numBounces;
    }

    public void Launch(int direction)
    {
        _direction = direction;
        _rigidbody.velocity = new Vector2 (_horizontalVelocity * _direction, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage damageable = collision.collider.GetComponent<ITakeDamage>();
        if (damageable != null)
        {
            damageable.TakeDamage();
            Destroy(gameObject);
            return;
        }

        _bouncesRemaining--;
        if (_bouncesRemaining < 0)
        {
            Destroy(gameObject);
            return;
        }

        Bounce();
    }

    void Bounce()
    {
        _rigidbody.velocity = new Vector2 (_horizontalVelocity * _direction, _bounceForce);
    }
}
