using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbtract
{
    [Header(" UIInventory Elements ")]
    [SerializeField] protected bool _isClose = false;
    [SerializeField] protected InventorySort _sortMode;

    public static UIInventory Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

    }

    protected override void Start()
    {
        base.Start();
        Hide();
        InvokeRepeating(nameof(ShowItems), 1, 1);
    }

    protected virtual void ShowItems()
    {
        if (_isClose) return;

        ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIItemInventorySpawner spawner = UIInventoryCtrl.UIItemInventorySpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }

        SortItems();
    }

    protected virtual void SortItems()
    {
        switch (_sortMode)
        {
            case InventorySort.ByName:
                SortUIInventoryItem();
                break;
            case InventorySort.ByCount:
                Debug.Log("Sort by count");
                break;
            default:
                Debug.Log("No Sort");
                break;
        }
    }

    protected virtual void SortUIInventoryItem()
    {
        int uiItemsCount = UIInventoryCtrl.Content.childCount;

        Transform currentItemTransform, nextItemTransform;
        string currentItemName, nextItemName;

        bool isSorting = false;

        for (int i = 0; i < uiItemsCount - 1; i++)
        {

            currentItemTransform = UIInventoryCtrl.Content.GetChild(i);

            nextItemTransform = UIInventoryCtrl.Content.GetChild(i + 1);

            currentItemName = currentItemTransform
                .GetComponent<UIInventoryItem>()
                .ItemInventory
                .ItemProfile
                .ItemName;

            nextItemName = nextItemTransform
                .GetComponent<UIInventoryItem>()
                .ItemInventory
                .ItemProfile
                .ItemName;

            bool isGreater = string.Compare(currentItemName, nextItemName) == 1 ? true : false;

            Debug.Log($"{currentItemName} vs {nextItemName} = {isGreater}");

            if (isGreater)
            {
                SwapUIInventoryItemTransform(currentItemTransform, nextItemTransform);
                isSorting = true;
            }
        }

        if (isSorting) SortUIInventoryItem();
    }

    protected virtual void SwapUIInventoryItemTransform(Transform currentItemTransform, Transform nextItemTransform)
    {
        int currentItemIndex = currentItemTransform.GetSiblingIndex();
        int nextItemIndex = nextItemTransform.GetSiblingIndex();

        currentItemTransform.SetSiblingIndex(nextItemIndex);
        nextItemTransform.SetSiblingIndex(currentItemIndex);
    }

    protected virtual void ClearItems()
    {
        UIInventoryCtrl.UIItemInventorySpawner.ClearItems();
    }

    public virtual void Toggle()
    {
        _isClose = !_isClose;

        if (_isClose)
            Hide();
        else
            Show();
    }

    public virtual void Show()
    {
        UIInventoryCtrl.gameObject.SetActive(true);
        _isClose = false;
    }

    public virtual void Hide()
    {
        UIInventoryCtrl.gameObject.SetActive(false);
        _isClose = true;
    }
}
