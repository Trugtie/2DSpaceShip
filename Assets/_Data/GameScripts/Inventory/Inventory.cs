using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected int _maxSlot = 70;
    [SerializeField] protected List<ItemInventory> _items;

    protected override void Start()
    {
        base.Start();
        AddItem(ItemCode.IronOre, 1);
        AddItem(ItemCode.GoldOre, 2);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = GetItemInventory(itemCode);
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > _maxSlot)
        {
            Debug.Log(transform.name + $": AddItem: {itemCode.ToString()} reached max slot");
            return false;
        }

        itemInventory.itemCount += addCount;
        return true;
    }

    protected virtual ItemInventory GetItemInventory(ItemCode itemCode)
    {
        ItemInventory itemInventory = _items.Find((item) => item.ItemProfile.ItemCode == itemCode);

        if (itemInventory == null)
            itemInventory = AddEmptyProfile(itemCode);

        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        string path = "ItemProfiles";
        ItemProfileSO[] itemProfiles = Resources.LoadAll<ItemProfileSO>(path);

        if (itemProfiles.Length < 1)
        {
            Debug.LogWarning(transform.name + ": AddEmptyProfile: No one ItemProfile!", gameObject);
            return null;
        }

        foreach (ItemProfileSO itemProfile in itemProfiles)
        {
            if (itemCode != itemProfile.ItemCode) continue;

            ItemInventory itemInventory = new ItemInventory()
            {
                ItemProfile = itemProfile,
                maxStack = itemProfile.defaultMaxStack,
            };

            _items.Add(itemInventory);

            return itemInventory;
        }

        Debug.LogWarning(transform.name + ": AddEmptyProfile: ItemProfile Not Found!", gameObject);

        return null;
    }
}
