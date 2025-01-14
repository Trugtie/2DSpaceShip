using System;
using UnityEngine;

public abstract class BaseAbility : BaseMonobehaviour
{
    [Header(" BaseAbility Settings ")]
    [SerializeField] protected Abilities _abilities;
    public Abilities Abilities => _abilities;

    [SerializeField] protected float _coolDownTime = 1f;
    [SerializeField] protected float _coolDownTimer;

    [SerializeField] protected bool _isReady = false;

    protected virtual void FixedUpdate()
    {
        CalculateCoolDown();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilities();
    }

    private void LoadAbilities()
    {
        if (_abilities != null) return;
        _abilities = GetComponentInParent<Abilities>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

    protected virtual void CalculateCoolDown()
    {
        if (_isReady) return;

        _coolDownTimer -= Time.fixedDeltaTime;

        if (_coolDownTimer > 0) return;

        _isReady = true;
    }

    public virtual void Active()
    {
        _isReady = false;
        _coolDownTimer = _coolDownTime;
    }

}
