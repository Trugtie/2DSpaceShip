using UnityEngine;

public class JunkDamgeReceiver : DamgeReceiver
{
    [Header(" ParentDenpendency ")]
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

        Debug.LogWarning(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        OnDeadVFX();
        _junkCtrl.JunkDespawn.DespawnOject();
        DropSystem.Instance.Drop(_junkCtrl.JunkSO._dropList);
    }

    protected virtual void OnDeadVFX()
    {
        string vfxName = GetOnDeadVFXName();
        Transform vfxTransform = VFXSpawner.Instance.Spawn(vfxName, transform.position, transform.rotation);
        vfxTransform.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadVFXName()
    {
        return VFXSpawner.EXPLODE_VFX_1;
    }

    protected override void Reborn()
    {
        _maxHP = _junkCtrl.JunkSO.JunkHP;
        base.Reborn();
    }
}
