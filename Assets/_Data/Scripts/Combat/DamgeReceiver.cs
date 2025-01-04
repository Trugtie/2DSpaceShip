using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DamgeReceiver : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    [Header(" Settings ")]
    [SerializeField] protected int _currentHP = 1;
    [SerializeField] protected int _maxHP = 2;
    [SerializeField] protected bool _isDead = false;

    protected override void Start()
    {
        base.Start();
        Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.37f;

        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected virtual void Reborn()
    {
        _currentHP = _maxHP;
        _isDead = false;
    }

    public virtual void Add(int add)
    {
        if (_isDead) return;

        _currentHP += add;

        if (_currentHP > _maxHP) _currentHP = _maxHP;
    }

    public virtual void Deduct(int deduct)
    {
        if (_isDead) return;

        _currentHP -= deduct;

        if (_currentHP < 0) _currentHP = 0;

        CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;

        _isDead = true;

        OnDead();
    }

    protected virtual bool IsDead()
    {
        return _currentHP <= 0;
    }

    protected virtual void OnDead()
    {

    }
}
