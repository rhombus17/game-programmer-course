using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
    }
}
