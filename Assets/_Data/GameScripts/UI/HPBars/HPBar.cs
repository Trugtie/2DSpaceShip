using System;
using UnityEngine;

public class HPBar : BaseMonobehaviour
{
    [Header("HPBar Elements")]
    [SerializeField] protected ShootableObjectCtrl _shootableObjectCtrl;
    [SerializeField] protected HPSlider _hpSlider;
    [SerializeField] protected FollowTarget _followTarget;

    protected virtual void FixedUpdate()
    {
        DisplayHP();
    }

    protected virtual void DisplayHP()
    {
        if (_shootableObjectCtrl == null) return;
        _hpSlider.SetCurrentHP(_shootableObjectCtrl.DamgeReceiver.CurrentHP);
        _hpSlider.SetMaxHP(_shootableObjectCtrl.DamgeReceiver.MaxHP);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHPSilder();
        LoadFollowTarget();
    }

    private void LoadFollowTarget()
    {
        if (_followTarget != null) return;
        _followTarget = GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }


    protected virtual void LoadHPSilder()
    {
        if (_hpSlider != null) return;
        _hpSlider = GetComponentInChildren<HPSlider>();
        Debug.LogWarning(transform.name + ": LoadHPSilder", gameObject);
    }

    public void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        _shootableObjectCtrl = shootableObjectCtrl;
    }

    public void SetFollowTarget(Transform newTarget)
    {
        _followTarget.SetTarget(newTarget);
    }
}
