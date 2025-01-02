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

        Instantiate(_bulletPrefab);
        Debug.Log("Shooting!");
    }
}
