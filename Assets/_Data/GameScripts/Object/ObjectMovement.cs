using TMPro;
using UnityEngine;

public class ObjectMovement : BaseMonobehaviour
{
    [Header(" ShipMovement Settings ")]
    [SerializeField] protected Vector3 _targetPosition;
    [SerializeField] protected float _maxSpeed = 0.01f;

    protected virtual void FixedUpdate()
    {
        Moving();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _maxSpeed = 0.01f;
    }

    public virtual void SetSpeed(float speed)
    {
        _maxSpeed = speed;
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, _targetPosition, _maxSpeed);
        transform.parent.position = newPos;
    }
}
