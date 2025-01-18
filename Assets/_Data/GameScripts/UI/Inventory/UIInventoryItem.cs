using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIInventoryItem : BaseMonobehaviour
{
    private const string ITEM_NAME_TEXT = "ItemNameText";
    private const string ITEM_COUNT_TEXT = "ItemCountText";
    private const string ITEM_IMAGE = "ItemImage";

    [Header(" UIInventoryItem Elements ")]
    [SerializeField] protected TextMeshProUGUI _itemNameText;
    [SerializeField] protected TextMeshProUGUI _itemCountText;
    [SerializeField] protected ItemInventory _itemInventory;
    [SerializeField] protected Image _itemImage;

    public ItemInventory ItemInventory => _itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemNameText();
        LoadItemCountText();
        LoadItemImage();
    }

    protected virtual void LoadItemImage()
    {
        if (_itemImage != null) return;
        _itemImage = transform.GetChild(0).Find(ITEM_IMAGE).GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadItemImage", gameObject);
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
        _itemImage.sprite = item.ItemProfile.ItemSprite;
        _itemInventory = item;
    }
}
