using System;
using UnityEngine;

public class ShipHPSlider : BaseSlider
{
    [Header(" ShipHPSlider Elements")]
    [SerializeField] protected float _currentHP = 70;
    [SerializeField] protected float _maxHP = 100;

    protected override void OnValueChange(float newValue)
    {
        //
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        DisplayHP();
    }

    private void DisplayHP()
    {
        _slider.value = _currentHP / _maxHP;
    }

    public virtual void SetCurrentHP(int hp)
    {
        _currentHP = hp;
    }

    public virtual void SetMaxHP(int hp)
    {
        _maxHP = hp;
    }
}
