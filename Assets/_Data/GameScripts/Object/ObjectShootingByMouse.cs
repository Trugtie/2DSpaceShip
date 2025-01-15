using UnityEngine;

public class ObjectShootingByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        _isShooting = InputManager.Instance.OnFiring == 1;

        return _isShooting;
    }
}
