using UnityEngine;

public class BulletCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected DamgeSender _damgeSender;
    [SerializeField] protected BulletDespawn _bulletDespawn;

    public DamgeSender DamgeSender { get => _damgeSender; }
    public BulletDespawn BulletDespawn { get => _bulletDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamgeSender();
        LoadBulletDespawn();
    }

    protected virtual void LoadDamgeSender()
    {
        if (_damgeSender != null) return;
        _damgeSender = GetComponentInChildren<DamgeSender>();
        Debug.Log(transform.name + ": LoadDamgeSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (_bulletDespawn != null) return;
        _bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }
}
