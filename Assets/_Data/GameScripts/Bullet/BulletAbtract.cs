using UnityEngine;

public class BulletAbtract : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected BulletCtrl _bulletCtrl;
    public BulletCtrl BulletCtrl { get => _bulletCtrl; }

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
}
