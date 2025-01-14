using UnityEngine;

public class ShipShootingByDistance : ShipShooting
{
    [Header(" ShipShootingByDistance Elements ")]
    [SerializeField] protected Transform _target;

    [Header(" ShipShootingByDistance Settings ")]
    [SerializeField] protected float _distanceWithTarget;
    [SerializeField] protected float _shootingDistance = 3f;

    protected override void ResetValue()
    {
        base.ResetValue();
        _shootingDistance = 3f;
    }

    public virtual void SetTarget(Transform target)
    {
        _target = target;
    }

    protected override bool IsShooting()
    {
        _distanceWithTarget = Vector3.Distance(transform.parent.position, _target.position);

        _isShooting = _distanceWithTarget < _shootingDistance;

        return _isShooting;
    }
}
