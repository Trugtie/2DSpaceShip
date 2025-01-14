using UnityEngine;

public abstract class ObjectShooting : BaseMonobehaviour
{
    [Header(" ShipShooting Elements ")]
    [SerializeField] protected bool _isShooting = false;

    [Header(" ShipShooting Settings ")]
    [SerializeField] protected float _shootDelay = 1f;
    [SerializeField] protected float _shootTimer;

    private void Update()
    {
        IsShooting();
    }
    private void FixedUpdate()
    {
        Shooting();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _shootDelay = 1f;
    }

    protected virtual void Shooting()
    {
        if (!_isShooting) return;

        _shootTimer += Time.fixedDeltaTime;
        if (_shootTimer < _shootDelay) return;
        _shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.BLUE_SMALL_PROJECTILES, spawnPos, rotation);
        if (bullet == null) return;

        BulletCtrl bullerCtrl = bullet.GetComponent<BulletCtrl>();
        bullerCtrl.SetShooter(transform.parent);

        bullet.gameObject.SetActive(true);
    }

    protected abstract bool IsShooting();
}
