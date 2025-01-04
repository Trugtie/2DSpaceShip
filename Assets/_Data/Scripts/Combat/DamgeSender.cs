using UnityEngine;

public class DamgeSender : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected float _damge = 2f;

    public virtual void SendDamgeToObject(Transform obj)
    {
        DamgeReceiver damgeReceiver = obj.GetComponentInChildren<DamgeReceiver>();

        if (damgeReceiver == null) return;

        Send(damgeReceiver);
    }

    protected virtual void Send(DamgeReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(_damge);
        DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
