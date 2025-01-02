using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected Vector3 _worldPosition;
    [SerializeField] protected float _maxSpeed = 0.1f;

    private void FixedUpdate()
    {
        _worldPosition = InputManager.Instance.MousePosition;
        _worldPosition.z = 0;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, _worldPosition, _maxSpeed);
        transform.parent.position = newPos;
    }
}
