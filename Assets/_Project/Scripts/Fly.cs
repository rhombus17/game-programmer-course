using UnityEngine;

public class Fly : MonoBehaviour
{
    Vector3 _startPosition;
    Vector2 _direction = Vector2.up;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime);
        var distance = Vector2.distance(_startPosition, transform.position);
        if (distance >= 2f)
        {
            _direction *= -1;
        }
    }
}
