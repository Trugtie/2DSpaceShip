using UnityEngine;

public class ShootableObjectDamgeReceiver : DamgeReceiver
{
    [Header(" ShootableObjectDamgeReceiver Elements ")]
    [SerializeField] protected ShootableObjectCtrl _shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (_shootableObjectCtrl != null) return;

        _shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();

        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

    protected override void OnDead()
    {
        OnDeadVFX();
        OnDropItem();
        _shootableObjectCtrl.Despawn.DespawnOject();

    }

    protected virtual void OnDropItem()
    {
        Vector3 dropPosition = transform.position;
        Quaternion dropRotation = transform.rotation;
        ItemSpawner.Instance.Drop(_shootableObjectCtrl.ShootableObjectSO._dropList, dropPosition, dropRotation);
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
        _maxHP = _shootableObjectCtrl.ShootableObjectSO.ShootableObjectHP;
        base.Reborn();
    }
}
