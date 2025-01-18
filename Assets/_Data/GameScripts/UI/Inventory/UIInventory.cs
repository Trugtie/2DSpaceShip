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
        if (_sortMode == InventorySort.NoSort) return;

        int uiItemsCount = UIInventoryCtrl.Content.childCount;

        Transform currentItemTransform, nextItemTransform;
        string currentItemName, nextItemName;
        int currentItemCount, nextItemCount;

        bool isSorting = false;

        for (int i = 0; i < uiItemsCount - 1; i++)
        {

            currentItemTransform = UIInventoryCtrl.Content.GetChild(i);

            nextItemTransform = UIInventoryCtrl.Content.GetChild(i + 1);

            bool isSwap = false;

            switch (_sortMode)
            {
                case InventorySort.ByName:
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

                    isSwap = string.Compare(currentItemName, nextItemName) == 1 ? true : false;

                    break;

                case InventorySort.ByCount:

                    currentItemCount = currentItemTransform
                         .GetComponent<UIInventoryItem>()
                         .ItemInventory
                         .itemCount;

                    nextItemCount = nextItemTransform
                        .GetComponent<UIInventoryItem>()
                         .ItemInventory
                         .itemCount;

                    isSwap = currentItemCount > nextItemCount;

                    break;
            }

            if (isSwap)
            {
                SwapUIInventoryItemTransform(currentItemTransform, nextItemTransform);
                isSorting = true;
            }
        }

        if (isSorting) SortItems();
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
