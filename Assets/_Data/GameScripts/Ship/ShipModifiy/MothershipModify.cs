using System;
using UnityEngine;

public class MothershipModify : ObjectModifyAbtract
{
    [Header(" MothershipModify Settings ")]
    [SerializeField] protected float _moveSpeed = 0.001f;
    [SerializeField] protected float _rotateSpeed = 0.1f;

    protected override void Start()
    {
        Modify();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _moveSpeed = 0.001f;
        _rotateSpeed = 0.1f;
        Modify();
    }

    protected virtual void Modify()
    {
        ShootableObjectCtrl.ObjectMovement.SetSpeed(_moveSpeed);
        ShootableObjectCtrl.ObjectLookAtTarget.SetRotateSpeed(_rotateSpeed);
    }
}
