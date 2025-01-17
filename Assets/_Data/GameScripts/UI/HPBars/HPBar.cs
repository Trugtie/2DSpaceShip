using System;
using UnityEngine;

public class HPBar : BaseMonobehaviour
{
    [Header("HPBar Elements")]
    [SerializeField] protected ShootableObjectCtrl _shootableObjectCtrl;
    [SerializeField] protected HPSlider _HPSlider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHPSilder();
    }

    protected virtual void FixedUpdate()
    {
        DisplayHP();
    }

    protected virtual void DisplayHP()
    {
        if (_shootableObjectCtrl == null) return;
        _HPSlider.SetCurrentHP(_shootableObjectCtrl.DamgeReceiver.CurrentHP);
        _HPSlider.SetMaxHP(_shootableObjectCtrl.DamgeReceiver.MaxHP);
    }

    protected virtual void LoadHPSilder()
    {
        if (_HPSlider != null) return;
        _HPSlider = GetComponentInChildren<HPSlider>();
        Debug.LogWarning(transform.name + ": LoadHPSilder", gameObject);
    }

    public void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        _shootableObjectCtrl = shootableObjectCtrl;
    }
}
