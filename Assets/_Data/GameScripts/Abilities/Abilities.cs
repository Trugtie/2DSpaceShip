using System;
using UnityEngine;

public class Abilities : BaseMonobehaviour
{
    [Header(" Abilities Elements ")]
    [SerializeField] protected AbilityObjectCtrl _abilityObjectCtrl;

    public AbilityObjectCtrl AbilityObjectCtrl => _abilityObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilityObjectCtrl();
    }

    protected virtual void LoadAbilityObjectCtrl()
    {
        if (_abilityObjectCtrl != null) return;
        _abilityObjectCtrl = GetComponentInParent<AbilityObjectCtrl>();
        Debug.LogWarning(transform.name + ": LoadAbilityObjectCtrl", gameObject);
    }
}
