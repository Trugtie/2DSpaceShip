using UnityEngine;

public class BulletDamgeSender : DamgeSender
{
    [Header(" Elements ")]
    [SerializeField] protected BulletCtrl _bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (_bulletCtrl != null) return;
        _bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected override void Send(DamgeReceiver damgeReceiver)
    {
        base.Send(damgeReceiver);
        DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        _bulletCtrl.BulletDespawn.DespawnOject();
    }
}
