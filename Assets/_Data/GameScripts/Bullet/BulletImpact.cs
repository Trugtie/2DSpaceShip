using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class BulletImpact : BulletAbtract
{
    [Header(" Elements ")]
    [SerializeField] protected CircleCollider2D _circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCircleCollider2D();
        LoadRigidbody2D();

    }

    protected virtual void LoadCircleCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.1f;

        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (_rigidbody2D != null) return;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;

        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletCtrl.DamgeSender.SendDamgeToObject(collision.transform);
        CreateImpactVFX(collision);
    }

    protected virtual void CreateImpactVFX(Collider2D collision)
    {
        string impactName = GetImpactVFX();

        Vector3 hitPos = collision.ClosestPoint(transform.position);
        Quaternion hitRot = CalculateRotateAngleToShooter(hitPos);

        Transform impactVFX = VFXSpawner.Instance.Spawn(impactName, hitPos, hitRot);
        impactVFX.gameObject.SetActive(true);
    }

    protected virtual Quaternion CalculateRotateAngleToShooter(Vector3 hitPos)
    {
        Vector3 directionToShooter = (_bulletCtrl.Shooter.position - hitPos).normalized;
        float angle = Mathf.Atan2(directionToShooter.y, directionToShooter.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }

    protected virtual string GetImpactVFX()
    {
        return VFXSpawner.IMPACT_1;
    }
}
