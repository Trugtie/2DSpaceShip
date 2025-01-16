using System;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header(" AbilityWarp Elements ")]
    [SerializeField] protected bool _isWarping = false;
    [SerializeField] protected Vector4 _warpDirection;

    [Header(" AbilityWarp Settings ")]
    [SerializeField] protected float _warpSpeed = 1f;
    [SerializeField] protected float _warpDistance = 2f;
    protected Vector4 _keyDirection;

    protected override void Update()
    {
        base.Update();
        CheckKeyWarping();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Warping();
    }

    protected virtual void CheckKeyWarping()
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

    protected virtual void Warping()
    {
        if (_isWarping) return;
        if (IsWarpDirectionNotSet()) return;

        Debug.Log("Warping");
        Debug.Log(_warpDirection);

        _isWarping = true;

        Invoke(nameof(WarpFinish), _warpSpeed);
    }

    protected virtual void WarpFinish()
    {
        Debug.Log("Warp Finish");
        MoveWarp();
        _warpDirection = Vector4.zero;
        _isWarping = false;
        Active();
    }

    protected virtual void MoveWarp()
    {
        Transform currentTransform = Abilities.AbilityObjectCtrl.transform;

        Vector3 newPos = currentTransform.position;

        if (_warpDirection.x == 1) newPos.x -= _warpDistance;
        if (_warpDirection.y == 1) newPos.x += _warpDistance;
        if (_warpDirection.z == 1) newPos.y += _warpDistance;
        if (_warpDirection.w == 1) newPos.y -= _warpDistance;

        currentTransform.position = newPos;
    }

    protected virtual bool IsWarpDirectionNotSet()
    {
        return _warpDirection == Vector4.zero;
    }
}
