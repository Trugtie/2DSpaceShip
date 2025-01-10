using System;
using UnityEngine;

public class ItemDropper : InventoryAbtract
{
    protected override void Start()
    {
        base.Start();

        //Test
        Invoke(nameof(TestDrop), 5);
    }

    //Test
    private void TestDrop()
    {
        DropItem(0);
    }

    protected virtual void DropItem(int itemIndex)
    {
        ItemInventory itemInventory = Inventory.Items[itemIndex];

        Vector3 dropPosition = transform.position;
        dropPosition.x += 2f;

        ItemSpawner.Instance.Drop(itemInventory, dropPosition, Quaternion.identity);

        Debug.Log("Drop");
    }
}
