using UnityEngine;

public abstract class InventoryAbtract : BaseMonobehaviour
{
    [Header(" Inventory Abtract ")]
    [SerializeField] protected Inventory _inventory;
    public Inventory Inventory => _inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (_inventory != null) return;
        _inventory = GetComponentInParent<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }
}
