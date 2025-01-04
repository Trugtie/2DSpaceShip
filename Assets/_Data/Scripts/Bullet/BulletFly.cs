using UnityEngine;

public class BulletFly : ParentObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _flySpeed = 20f;
        _direction = Vector3.right;
    }
}
