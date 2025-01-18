using System;
using TMPro;
using UnityEngine;


public class UIInventoryItem : BaseMonobehaviour
{
    private const string ITEM_NAME_TEXT = "ItemNameText";
    private const string ITEM_COUNT_TEXT = "ItemCountText";

    [Header(" UIInventoryItem Elements ")]
    [SerializeField] protected TextMeshProUGUI _itemNameText;
    [SerializeField] protected TextMeshProUGUI _itemCountText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemNameText();
        LoadItemCountText();
    }

    protected virtual void LoadItemCountText()
    {
        if (_itemCountText != null) return;
        _itemCountText = transform.GetChild(0).Find(ITEM_COUNT_TEXT).GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadItemCountText", gameObject);
    }

    protected virtual void LoadItemNameText()
    {
        if (_itemNameText != null) return;
        _itemNameText = transform.GetChild(0).Find(ITEM_NAME_TEXT).GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadItemNameText", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        _itemNameText.SetText(item.ItemProfile.ItemName);
        _itemCountText.SetText(item.itemCount.ToString());
    }
}
