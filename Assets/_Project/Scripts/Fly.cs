using UnityEngine;

public class Fly : MonoBehaviour, ITakeDamage
{
    Vector2 _startPosition;
    [SerializeField] Vector2 _direction = Vector2.up;
    [SerializeField] float _maxDistance = 2f;
    [SerializeField] float _speed = 3f;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(_direction.normalized * Time.deltaTime * _speed);
        var distance = Vector2.Distance(_startPosition, transform.position);
        if (distance >= _maxDistance)
        {
            transform.position = _startPosition + (_direction.normalized * _maxDistance);
            _direction *= -1;
        }
    }

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }
}
