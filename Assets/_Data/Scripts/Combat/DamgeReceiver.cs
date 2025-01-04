using UnityEngine;

public class DamgeReceiver : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected float _currentHP = 1f;
    [SerializeField] protected float _maxHP = 1f;

    protected override void Start()
    {
        base.Start();
        Reborn();
    }

    protected virtual void Reborn()
    {
        _currentHP = _maxHP;
    }

    public virtual void Add(float add)
    {
        _currentHP += add;

        if (_currentHP > _maxHP) _currentHP = _maxHP;
    }

    public virtual void Deduct(float deduct)
    {
        _currentHP -= deduct;

        if (_currentHP < 0) _currentHP = 0;
    }

    public virtual bool IsDead()
    {
        return _currentHP <= 0;
    }
}
