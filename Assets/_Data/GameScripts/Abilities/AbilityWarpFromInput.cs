using System;
using UnityEngine;

public class AbilityWarpFromInput : AbilityWarp
{
    protected override void Update()
    {
        base.Update();
        UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection()
    {
        _keyDirection = InputManager.Instance.Direction;
    }
}
