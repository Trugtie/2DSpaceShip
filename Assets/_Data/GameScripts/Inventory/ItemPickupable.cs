using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickupable : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.3f;

        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    public static ItemCode StringToItemCode(string name)
    {
        return (ItemCode)Enum.Parse(typeof(ItemCode), name);
    }

    public virtual ItemCode GetItemCode()
    {
        return StringToItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        Destroy(transform.parent.gameObject);
    }
}
