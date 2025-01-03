using UnityEngine;

public class JunkFly : ParentObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _flySpeed = 1f;
        _direction = Vector3.right;
    }
}
