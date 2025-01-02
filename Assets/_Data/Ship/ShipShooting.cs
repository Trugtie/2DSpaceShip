using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected bool _isShooting = false;

    [Header(" Settings ")]
    [SerializeField] protected float _shootDelay;
    [SerializeField] protected float _shootTimer;

    private void Update()
    {
        IsShooting();
    }
    private void FixedUpdate()
    {
        Shooting();
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
        bullet.gameObject.SetActive(true);

        Debug.Log("Shooting!");
    }

    protected virtual bool IsShooting()
    {
        _isShooting = InputManager.Instance.OnFiring == 1;

        return _isShooting;
    }
}
