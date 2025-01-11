using System;
using UnityEngine;

public class ItemCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected ItemDespawn _itemDespawn;
    [SerializeField] protected ItemInventory _itemInventory;
    public ItemDespawn ItemDespawn => _itemDespawn;
    public ItemInventory ItemInventory => _itemInventory;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetItem();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
        LoadItemInventory();
    }

    protected virtual void LoadItemDespawn()
    {
        if (_itemDespawn != null) return;
        _itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.LogWarning(transform.name + ": LoadItemDespawn", gameObject);
    }

    public virtual void SetItemIventory(ItemInventory itemInventory)
    {
        _itemInventory = itemInventory.Clone();
    }

    protected virtual void LoadItemInventory()
    {
        if (_itemInventory.ItemProfile != null) return;

        ItemCode itemCode = ItemCodeParse.ParseFormString(transform.name);

        ItemProfileSO itemProfileSO = ItemProfileSO.FindByItemCode(itemCode);

        if (itemProfileSO == null) return;

        _itemInventory.ItemProfile = itemProfileSO;

        ResetItem();

        Debug.LogWarning(transform.name + ": LoadItemInventory", gameObject);
    }

    private void ResetItem()
    {
        _itemInventory.itemCount = 1;
        _itemInventory.upgradeLevel = 0;
    }
}
