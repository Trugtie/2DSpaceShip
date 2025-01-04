using UnityEngine;

public class DamgeSender : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected int _damge = 1;

    public virtual void SendDamgeToObject(Transform obj)
    {
        DamgeReceiver damgeReceiver = obj.GetComponentInChildren<DamgeReceiver>();

        if (damgeReceiver == null) return;

        Send(damgeReceiver);
    }

    protected virtual void Send(DamgeReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(_damge);
    }
}
