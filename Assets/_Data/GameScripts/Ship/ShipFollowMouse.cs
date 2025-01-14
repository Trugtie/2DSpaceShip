using TMPro;
using UnityEngine;

public class ShipFollowMouse : ObjectMovement
{
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected void GetMousePosition()
    {
        _targetPosition = InputManager.Instance.MousePosition;
        _targetPosition.z = 0;
    }
}
