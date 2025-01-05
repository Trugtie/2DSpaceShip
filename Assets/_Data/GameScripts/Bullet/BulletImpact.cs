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
    }
}
