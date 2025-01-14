using System;
using UnityEngine;

public abstract class ShootableObjectAbtract : BaseMonobehaviour
{
    [Header(" ShootableObjectCtrl Elements ")]
    [SerializeField] protected ShootableObjectCtrl _shootableObjectCtrl;

    public ShootableObjectCtrl ShootableObjectCtrl => _shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (_shootableObjectCtrl != null) return;

        _shootableObjectCtrl = GetComponentInParent<ShootableObjectCtrl>();

        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl ", gameObject);
    }
}
