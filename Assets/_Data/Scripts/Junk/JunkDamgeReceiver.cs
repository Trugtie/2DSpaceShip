using UnityEngine;

public class JunkDamgeReceiver : DamgeReceiver
{
    [Header(" Elements ")]
    [SerializeField] protected JunkCtrl _junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (_junkCtrl != null) return;

        _junkCtrl = transform.parent.GetComponent<JunkCtrl>();

        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        _junkCtrl.JunkDespawn.DespawnOject();
    }
}
