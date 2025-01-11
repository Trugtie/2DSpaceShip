using System;

[Serializable]
public class ItemInventory
{
    public ItemProfileSO ItemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory itemInventory = new ItemInventory()
        {
            ItemProfile = ItemProfile,
            itemCount = itemCount,
            upgradeLevel = upgradeLevel,
        };

        return itemInventory;
    }
}
