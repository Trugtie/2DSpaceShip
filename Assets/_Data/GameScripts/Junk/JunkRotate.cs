using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [Header(" Settings ")]
    [SerializeField] protected float _rotateSpeed = 10f;
    [SerializeField] protected Vector3 _rotateDirection = Vector3.forward;

    protected virtual void FixedUpdate()
    {
        Rotating();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _rotateSpeed = 10f;
        _rotateDirection = Vector3.forward;
    }

    protected virtual void Rotating()
    {
        JunkCtrl.Model.Rotate(_rotateDirection * _rotateSpeed * Time.fixedDeltaTime);
    }
}
