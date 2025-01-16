using System;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header(" AbilityWarp Elements ")]
    [SerializeField] protected Vector4 _warpDirection;
    [SerializeField] protected bool _isWarping;
    protected Vector4 _keyDirection;

    protected override void Update()
    {
        base.Update();
        Warping();
    }

    protected virtual void Warping()
    {
        if (!_isReady) return;
        if (_isWarping) return;

        if (_keyDirection.x == 1) WarpLeft();
        if (_keyDirection.y == 1) WarpRight();
        if (_keyDirection.z == 1) WarpUp();
        if (_keyDirection.w == 1) WarpDown();
    }

    protected virtual void WarpLeft()
    {
        Debug.Log("Left");
        _warpDirection.x = 1;
    }
    protected virtual void WarpRight()
    {
        Debug.Log("Right");
        _warpDirection.y = 1;
    }
    protected virtual void WarpUp()
    {
        Debug.Log("Up");
        _warpDirection.z = 1;
    }
    protected virtual void WarpDown()
    {
        Debug.Log("Down");
        _warpDirection.w = 1;
    }
}
