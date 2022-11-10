using UnityEngine;

public class ItemBox : HittableFromBelow
{
    [SerializeField] GameObject _item;
    [SerializeField] Vector2 _itemLaunchVelocity;

    bool _used;

    protected override bool CanUse => !_used;

    void Start()
    {
        if (_item != null)
            _item.SetActive(false);
    }

    protected override void Use()
    {
        _used = true;
        GetComponent<SpriteRenderer>().sprite = _emptyBoxSprite;
        if (_item == null)
            return;
        _item.SetActive(true);
        
        var itemRigidbody = _item.GetComponent<Rigidbody2D>();
        if (itemRigidbody == null)
            return;
        itemRigidbody.velocity = _itemLaunchVelocity;
    }
}
