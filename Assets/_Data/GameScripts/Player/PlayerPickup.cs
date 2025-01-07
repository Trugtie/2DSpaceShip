using UnityEngine;

public class PlayerPickup : PlayerAbtract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();

        if (_playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
