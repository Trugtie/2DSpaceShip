using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected Transform _bulletPrefab;
    [SerializeField] protected bool _isShooting = false;

    private void FixedUpdate()
    {
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
}
