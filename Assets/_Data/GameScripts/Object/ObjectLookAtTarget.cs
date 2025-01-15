using TMPro;
using UnityEngine;

public class ObjectLookAtTarget : BaseMonobehaviour
{
    [Header(" ObjectLookAtTarget Settings ")]
    [SerializeField] protected Vector3 _targetPosition;
    [SerializeField] protected float _rotateSpeed = 10f;

    protected virtual void FixedUpdate()
    {
        LookAtTargetPosition();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _rotateSpeed = 10f;
    }

    public virtual void SetRotateSpeed(float speed)
    {
        _rotateSpeed = speed;
    }

    protected virtual void LookAtTargetPosition()
    {
        Vector2 currentPosition = transform.parent.position;
        Vector2 direction = (Vector2)_targetPosition - currentPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, _rotateSpeed * Time.fixedDeltaTime);
    }
}
