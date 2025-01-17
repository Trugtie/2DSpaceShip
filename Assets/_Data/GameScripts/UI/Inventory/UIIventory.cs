using System;
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

    protected virtual void FixedUpdate()
    {
        //ShowItems();
    }

    protected virtual void ShowItems()
    {
        if (_isClose) return;

        ClearItems();

        for (int i = 1; i < PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count; i++)
        {
            SpawnTest(i);
        }
    }

    protected virtual void ClearItems()
    {
        UIIventoryCtrl.UIItemInventorySpawner.ClearItems();
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = UIIventoryCtrl.UIItemInventorySpawner.Spawn(UIItemInventorySpawner.UI_INVENTORY_ITEM, Vector3.zero, Quaternion.identity);
        uiItem.localScale = Vector3.one;
        uiItem.gameObject.SetActive(true);
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
