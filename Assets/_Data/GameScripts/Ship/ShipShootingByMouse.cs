using UnityEngine;

public class ShipShootingByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        _isShooting = InputManager.Instance.OnFiring == 1;

        return _isShooting;
    }
}
