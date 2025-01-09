using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/New ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode ItemCode = ItemCode.NoItem;
    public ItemType ItemType = ItemType.NoType;
    public string ItemName = "No Name";
    public int DefaultMaxStack = 7;
    public List<ItemRecipe> ItemRecipesNeedToUpgradePerLevel;
}
