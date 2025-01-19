using System;
using UnityEngine;

public abstract class UIHotKeyAbtract : BaseMonobehaviour
{
    [Header(" UIHotKeyAbtract Elements ")]
    [SerializeField] protected UIHotKeyCtrl _uiHotkeyCtrl;

    public UIHotKeyCtrl UIHotkeyCtrl => _uiHotkeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIHotKeyCtrl();
    }

    protected virtual void LoadUIHotKeyCtrl()
    {
        if (_uiHotkeyCtrl != null) return;
        _uiHotkeyCtrl = GetComponentInParent<UIHotKeyCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIHotKeyCtrl", gameObject);
    }
}
