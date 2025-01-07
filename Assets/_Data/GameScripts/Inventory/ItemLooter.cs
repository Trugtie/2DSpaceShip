using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class ItemLooter : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected Inventory _inventory;
    [SerializeField] protected CircleCollider2D _circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider2D();
        LoadRigidbody2D();
        LoadInventory();
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

    protected virtual void LoadInventory()
    {
        if (_inventory != null) return;
        _inventory = transform.parent.GetComponent<Inventory>();

        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();

        if (_inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
