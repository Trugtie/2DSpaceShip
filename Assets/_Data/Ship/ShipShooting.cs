using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected Transform _bulletPrefab;
    [SerializeField] protected bool _isShooting = false;

    private void FixedUpdate()
    {
        IsShooting();
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!_isShooting) return;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Instantiate(_bulletPrefab, spawnPos, transform.parent.rotation);

        Debug.Log("Shooting!");
    }

    protected virtual bool IsShooting()
    {
        _isShooting = InputManager.Instance.OnFiring == 1;

        return _isShooting;
    }
}
