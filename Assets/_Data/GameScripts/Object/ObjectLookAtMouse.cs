using TMPro;
using UnityEngine;

public class ObjectLookAtMouse : ObjectLookAtTarget
{
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _rotateSpeed = 10f;
    }

    protected void GetMousePosition()
    {
        _targetPosition = InputManager.Instance.MousePosition;
        _targetPosition.z = 0;
    }
}
