using UnityEngine;

public class BulletCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected DamgeSender _damgeSender;
    [SerializeField] protected BulletDespawn _bulletDespawn;
    [SerializeField] protected Transform _shooter;

    public DamgeSender DamgeSender => _damgeSender;
    public BulletDespawn BulletDespawn => _bulletDespawn;
    public Transform Shooter => _shooter;

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

    public virtual void SetShooter(Transform shooter)
    {
        _shooter = shooter;
    }
}
