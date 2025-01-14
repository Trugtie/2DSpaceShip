using TMPro;
using UnityEngine;

public class ShipFollowTarget : ShipMovement
{
    [Header(" ShipFollowTarget Elements ")]
    [SerializeField] protected Transform _target;

    [Header(" ShipFollowTarget Settings ")]
    [SerializeField] protected float _minDistanceWithTarget = 3f;
    [SerializeField] protected float _distanceWithTarget;

    protected override void FixedUpdate()
    {
        GetTargetPosition();
        base.FixedUpdate();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _minDistanceWithTarget = 3f;
    }

    public virtual void SetTarget(Transform target)
    {
        _target = target;
    }

    protected void GetTargetPosition()
    {
        _targetPosition = _target.position;
        _targetPosition.z = 0;
    }

    protected override void Moving()
    {
        _distanceWithTarget = Vector3.Distance(transform.parent.position, _target.position);
        if (_distanceWithTarget < _minDistanceWithTarget) return;

        base.Moving();
    }
}
