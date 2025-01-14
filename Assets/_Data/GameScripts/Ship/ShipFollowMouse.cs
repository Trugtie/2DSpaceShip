using TMPro;
using UnityEngine;

public class ShipFollowMouse : ObjectMovement
{
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _maxSpeed = 0.01f;
        _rotateSpeed = 100f;
    }

    protected void GetMousePosition()
    {
        _targetPosition = InputManager.Instance.MousePosition;
        _targetPosition.z = 0;
    }
}
