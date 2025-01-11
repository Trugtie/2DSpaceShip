using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class ItemLooter : InventoryAbtract
{
    [Header(" Elements ")]
    [SerializeField] protected CircleCollider2D _circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider2D();
        LoadRigidbody2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.7f;

        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (_rigidbody2D != null) return;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;

        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if (_inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
