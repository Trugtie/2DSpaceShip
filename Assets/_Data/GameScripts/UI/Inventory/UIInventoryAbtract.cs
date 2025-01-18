using System;
using UnityEngine;

public abstract class UIInventoryAbtract : BaseMonobehaviour
{

    [Header(" UIIventoryAbtract Elements ")]
    [SerializeField] protected UIInventoryCtrl _uiInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => _uiInventoryCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIInventoryCtrl();
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (_uiInventoryCtrl != null) return;
        _uiInventoryCtrl = GetComponentInParent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }
}
