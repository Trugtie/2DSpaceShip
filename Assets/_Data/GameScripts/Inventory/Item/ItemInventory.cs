using System;

[Serializable]
public class ItemInventory
{
    public string ItemID;
    public ItemProfileSO ItemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory itemInventory = new ItemInventory()
        {
            ItemID = RandomID(),
            ItemProfile = ItemProfile,
            itemCount = itemCount,
            upgradeLevel = upgradeLevel,
        };

        return itemInventory;
    }

    public static string RandomID()
    {
        return RandomStringGenerator.Generate(27);
    }
}
