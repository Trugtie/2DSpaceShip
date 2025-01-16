using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header(" Elements ")]
    [SerializeField] protected Inventory _inventory;
    public Inventory Inventory => _inventory;

    protected override string GetStringFromObjectType()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (_inventory != null) return;
        _inventory = GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }
}
