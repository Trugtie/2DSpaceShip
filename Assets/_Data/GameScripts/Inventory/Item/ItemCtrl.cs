using UnityEngine;

public class ItemCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected ItemDespawn _itemDespawn;
    public ItemDespawn ItemDespawn => _itemDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
    }

    protected virtual void LoadItemDespawn()
    {
        if (_itemDespawn != null) return;
        _itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.LogWarning(transform.name + ": LoadItemDespawn", gameObject);
    }
}
