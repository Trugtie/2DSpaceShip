using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/New ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode ItemCode = ItemCode.NoItem;
    public ItemType ItemType = ItemType.NoType;
    public string ItemName = "No Name";
    public int defaultMaxStack = 7;
}
