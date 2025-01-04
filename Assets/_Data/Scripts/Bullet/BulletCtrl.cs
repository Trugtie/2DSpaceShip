using UnityEngine;

public class BulletCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected DamgeSender _damgeSender;
    public DamgeSender DamgeSender { get => _damgeSender; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamgeSender();
    }

    protected virtual void LoadDamgeSender()
    {
        if (_damgeSender != null) return;
        _damgeSender = GetComponentInChildren<DamgeSender>();
        Debug.Log(transform.name + ": LoadDamgeSender", gameObject);
    }
}
