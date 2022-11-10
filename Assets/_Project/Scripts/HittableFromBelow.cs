using UnityEngine;

public class HittableFromBelow : MonoBehaviour
{
    [SerializeField] protected Sprite _emptyBoxSprite;

    protected virtual bool CanUse => true;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!CanUse)
            return;
        
        var player = col.collider.GetComponent<Player>();
        if (player == null)
            return;
        
        if (col.contacts[0].normal.y <= 0)
            return;

        Use();
        if (!CanUse)
            GetComponent<SpriteRenderer>().sprite = _emptyBoxSprite;
    }

    protected virtual void Use()
    {
        
    }
}
