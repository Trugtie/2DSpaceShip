using UnityEngine;

[CreateAssetMenu(fileName = "New ItemSO", menuName = "SO/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemCode ItemCode = ItemCode.NoItem;
    public string ItemName = "Item Name";
}
