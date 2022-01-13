using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    [SerializeField] float _bounceVelocity = 10f;
    [SerializeField] Sprite _downSprite;

    SpriteRenderer _spriteRenderer;
    Sprite _upSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _upSprite = _spriteRenderer.sprite;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player == null)
            return;
        
        var rigidbody2D = player.GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
        {
            Debug.LogError("Player does not have a rigidBody");
            return;
        }

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _bounceVelocity);
        _spriteRenderer.sprite = _downSprite;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player == null)
            return;

        _spriteRenderer.sprite = _upSprite;
    }
}
