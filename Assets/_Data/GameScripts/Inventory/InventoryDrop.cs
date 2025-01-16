using System;
using UnityEngine;

public class InventoryDrop : InventoryAbtract
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
        Vector3 dropPosition = transform.position;
        dropPosition.x += 2f;
        DropItem(0, dropPosition, Quaternion.identity);
    }

    protected virtual void DropItem(int itemIndex, Vector3 dropPosition, Quaternion dropRotation)
    {
        ItemInventory itemInventory = Inventory.Items[itemIndex];

        ItemSpawner.Instance.DropFromInventory(itemInventory, dropPosition, dropRotation);

        _inventory.Items.Remove(itemInventory);

        Debug.Log("Drop");
    }
}
