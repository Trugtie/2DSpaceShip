using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{

    [Header(" ItemSpawner Settings ")]
    [SerializeField] protected float _gameDropRate = 1f;

    public static ItemSpawner Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 dropPosition, Quaternion dropRotation)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return droppedItems;

        droppedItems = GetDropItems(dropList);

        foreach (ItemDropRate item in droppedItems)
        {
            ItemCode itemCode = item.ItemProfileSO.ItemCode;

            Transform itemDrop = Spawn(itemCode.ToString(), dropPosition, dropRotation);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return droppedItems;
    }

    protected virtual List<ItemDropRate> GetDropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        float rate, itemRate;

        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.DropRate * _gameDropRate;

            if (rate <= itemRate)
                dropItems.Add(item);
        }

        return dropItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemIventory, Vector3 dropPosition, Quaternion dropRotation)
    {
        ItemCode itemCode = itemIventory.ItemProfile.ItemCode;

        Transform itemDropped = Spawn(itemCode.ToString(), dropPosition, dropRotation);

        if (itemDropped == null) return null;

        itemDropped.gameObject.SetActive(true);
        itemDropped.GetComponent<ItemCtrl>().SetItemIventory(itemIventory);

        return itemDropped;
    }
}
