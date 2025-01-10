using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected int _maxSlot = 70;
    [SerializeField] protected List<ItemInventory> _items;

    public List<ItemInventory> Items => _items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.IronOre, 9);
        this.AddItem(ItemCode.GoldOre, 8);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = GetItemProfileByItemCode(itemCode);

        int addRemain = addCount;
        ItemInventory itemNotFullStack;

        for (int i = 0; i < _maxSlot; i++)
        {
            itemNotFullStack = FindItemNotFullStack(itemProfile);

            if (itemNotFullStack == null)
            {
                if (IsFullInventory()) return false;

                itemNotFullStack = CreateEmptyItemInventory(itemProfile);
                _items.Add(itemNotFullStack);
            }

            int newCount = itemNotFullStack.itemCount + addRemain;

            int maxStackOfItemNotFullStack = GetMaxStackOfItem(itemNotFullStack);

            if (newCount > maxStackOfItemNotFullStack)
            {
                int itemNeedToAdd = maxStackOfItemNotFullStack - itemNotFullStack.itemCount;
                newCount = itemNotFullStack.itemCount + itemNeedToAdd;
                addRemain -= itemNeedToAdd;
            }
            else
            {
                addRemain -= newCount;
            }

            itemNotFullStack.itemCount = newCount;
            if (addRemain < 1) break;
        }

        return true;
    }

    protected virtual ItemProfileSO GetItemProfileByItemCode(ItemCode itemCode)
    {
        const string ITEM = "Item";

        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>(ITEM);

        foreach (ItemProfileSO itemProfileSO in itemProfileSOs)
        {
            if (itemProfileSO.ItemCode != itemCode) continue;
            return itemProfileSO;
        }

        return null;
    }

    protected virtual ItemInventory FindItemNotFullStack(ItemProfileSO itemProfile)
    {
        foreach (ItemInventory itemInventory in _items)
        {
            if (itemInventory.ItemProfile != itemProfile) continue;
            if (IsItemFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    protected virtual bool IsItemFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = GetMaxStackOfItem(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual bool IsFullInventory()
    {
        if (_items.Count >= _maxSlot) return true;
        return false;
    }

    protected virtual ItemInventory CreateEmptyItemInventory(ItemProfileSO itemProfile)
    {
        ItemInventory emptyItemInventory = new ItemInventory()
        {
            ItemProfile = itemProfile,
            maxStack = itemProfile.DefaultMaxStack,
        };

        return emptyItemInventory;
    }

    protected virtual int GetMaxStackOfItem(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deductValue;

        for (int i = _items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = _items[i];

            if (itemInventory.ItemProfile.ItemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deductValue = itemInventory.itemCount;
                deductCount -= deductValue;
            }
            else
            {
                deductValue = deductCount;
                deductCount -= deductValue;
            }

            itemInventory.itemCount -= deductValue;
        }

        ClearEmptyItem();
    }

    protected virtual void ClearEmptyItem()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].itemCount < 1)
                _items.RemoveAt(i);
        }
    }
}
