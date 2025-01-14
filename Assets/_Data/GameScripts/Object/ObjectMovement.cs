using TMPro;
using UnityEngine;

public class ObjectMovement : BaseMonobehaviour
{
    [Header(" ShipMovement Settings ")]
    [SerializeField] protected Vector3 _targetPosition;
    [SerializeField] protected float _maxSpeed = 0.01f;
    [SerializeField] protected float _rotateSpeed = 10f;

    protected virtual void FixedUpdate()
    {
        LookAtTargetPosition();
        Moving();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _maxSpeed = 0.01f;
        _rotateSpeed = 10f;
    }

    protected virtual void LookAtTargetPosition()
    {
        Vector2 currentPosition = transform.parent.position;
        Vector2 direction = (Vector2)_targetPosition - currentPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, _rotateSpeed * Time.fixedDeltaTime);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, _targetPosition, _maxSpeed);
        transform.parent.position = newPos;
    }
}
