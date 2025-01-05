using TMPro;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected Vector3 _targetPosition;
    [SerializeField] protected float _maxSpeed = 0.1f;

    private void FixedUpdate()
    {
        GetTargetPosition();
        LookAtTargetPosition();
        Moving();
    }

    protected void LookAtTargetPosition()
    {
        Vector2 currentPosition = transform.parent.position;
        Vector2 direction = (Vector2)_targetPosition - currentPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected void GetTargetPosition()
    {
        _targetPosition = InputManager.Instance.MousePosition;
        _targetPosition.z = 0;
    }

    protected void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, _targetPosition, _maxSpeed);
        transform.parent.position = newPos;
    }
}
