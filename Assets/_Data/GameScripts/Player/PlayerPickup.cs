using UnityEngine;

public class PlayerPickup : PlayerAbtract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if (_playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
