using System;
using UnityEngine;

public abstract class UIIventoryAbtract : BaseMonobehaviour
{

    [Header(" UIIventoryAbtract Elements ")]
    [SerializeField] protected UIIventoryCtrl _uiIventoryCtrl;
    public UIIventoryCtrl UIIventoryCtrl => _uiIventoryCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIIventoryCtrl();
    }

    protected virtual void LoadUIIventoryCtrl()
    {
        if (_uiIventoryCtrl != null) return;
        _uiIventoryCtrl = GetComponentInParent<UIIventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIIventoryCtrl", gameObject);
    }
}
