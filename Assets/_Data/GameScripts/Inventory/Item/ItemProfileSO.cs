using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/New ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode ItemCode = ItemCode.NoItem;
    public ItemType ItemType = ItemType.NoType;
    public string ItemName = "No Name";
    public int DefaultMaxStack = 7;
    public Sprite ItemSprite = null;
    public List<ItemRecipe> ItemRecipesNeedToUpgradePerLevel;

    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        string path = "Item";

        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>(path);

        foreach (ItemProfileSO itemProfileSO in itemProfileSOs)
        {
            if (itemProfileSO.ItemCode != itemCode) continue;
            return itemProfileSO;
        }

        return null;
    }
}
