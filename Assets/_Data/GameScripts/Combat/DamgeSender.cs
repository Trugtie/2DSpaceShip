using UnityEngine;

public class DamgeSender : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected int _damge = 1;

    public virtual void SendDamgeToObject(Collider2D objectReceiver, Transform objectSender)
    {
        DamgeReceiver damgeReceiver = objectReceiver.GetComponentInChildren<DamgeReceiver>();

        if (damgeReceiver == null) return;

        Send(damgeReceiver);
        CreateImpactVFX(objectReceiver, objectSender.transform.position);
    }

    protected virtual void Send(DamgeReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(_damge);
    }

    protected virtual void CreateImpactVFX(Collider2D collision, Vector3 shooterPosition)
    {
        string impactName = GetImpactVFX();

        Vector3 hitPos = collision.ClosestPoint(transform.position);
        Quaternion hitRot = CalculateRotateAngleToShooter(hitPos, shooterPosition);

        Transform impactVFX = VFXSpawner.Instance.Spawn(impactName, hitPos, hitRot);
        impactVFX.gameObject.SetActive(true);
    }

    protected virtual Quaternion CalculateRotateAngleToShooter(Vector3 hitPosition, Vector3 shooterPosition)
    {
        Vector3 directionToShooter = (shooterPosition - hitPosition).normalized;
        float angle = Mathf.Atan2(directionToShooter.y, directionToShooter.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }

    protected virtual string GetImpactVFX()
    {
        return VFXSpawner.IMPACT_1;
    }

}
