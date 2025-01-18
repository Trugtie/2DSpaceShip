using System.Collections.Generic;
using UnityEngine;

public class UIIventory : UIIventoryAbtract
{
    [Header(" UIInventory Elements ")]
    [SerializeField] protected bool _isClose = false;

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
