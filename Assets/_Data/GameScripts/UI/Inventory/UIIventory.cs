using System;
using UnityEngine;

public class UIIventory : BaseMonobehaviour
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
    }

    protected virtual void FixedUpdate()
    {
        ShowItems();
    }

    protected virtual void ShowItems()
    {
        if (_isClose) return;

        Debug.Log(PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count);
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
        gameObject.SetActive(true);
        _isClose = false;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        _isClose = true;
    }
}
