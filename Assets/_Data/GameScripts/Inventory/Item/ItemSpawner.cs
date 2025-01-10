using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
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

    public virtual void Drop(List<DropRate> dropList, Vector3 dropPosition, Quaternion dropRotation)
    {
        ItemCode itemCode = dropList[0].ItemProfileSO.ItemCode;

        Transform itemDrop = Spawn(itemCode.ToString(), dropPosition, dropRotation);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemIventory, Vector3 dropPosition, Quaternion dropRotation)
    {
        ItemCode itemCode = itemIventory.ItemProfile.ItemCode;

        Transform itemDrop = Spawn(itemCode.ToString(), dropPosition, dropRotation);

        if (itemDrop == null) return null;

        itemDrop.gameObject.SetActive(true);

        return itemDrop;
    }
}
