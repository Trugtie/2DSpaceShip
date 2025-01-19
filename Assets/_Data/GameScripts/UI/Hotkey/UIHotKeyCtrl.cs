using System;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : BaseMonobehaviour
{
    public static UIHotKeyCtrl Instance { get; private set; }

    [Header(" UIHotKeyCtrl Elements ")]
    [SerializeField] protected List<ItemSlot> _itemSlots = new List<ItemSlot>();

    public List<ItemSlot> ItemSlots => _itemSlots;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (_itemSlots.Count > 0) return;
        ItemSlot[] itemSlotArrray = GetComponentsInChildren<ItemSlot>();
        _itemSlots.AddRange(itemSlotArrray);
        Debug.LogWarning(transform.name + ": LoadItemSlots", gameObject);
    }
}
