using System;
using System.Collections.Generic;
using UnityEngine;

public class UIIventory : UIIventoryAbtract
{
    [Header(" UIInventory Elements ")]
    [SerializeField] protected bool _isClose = false;
    [SerializeField] protected InventorySort _sortMode;

    public static UIIventory Instance { get; private set; }

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
        UIItemInventorySpawner spawner = UIIventoryCtrl.UIItemInventorySpawner;

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
                Debug.Log("Sort by name");
                break;
            case InventorySort.ByCount:
                Debug.Log("Sort by count");
                break;
            default:
                Debug.Log("No Sort");
                break;
        }
    }

    protected virtual void ClearItems()
    {
        UIIventoryCtrl.UIItemInventorySpawner.ClearItems();
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
        UIIventoryCtrl.gameObject.SetActive(true);
        _isClose = false;
    }

    public virtual void Hide()
    {
        UIIventoryCtrl.gameObject.SetActive(false);
        _isClose = true;
    }
}
