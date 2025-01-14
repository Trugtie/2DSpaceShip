using UnityEngine;

public class ShipShootingByMouse : ShipShooting
{
    protected override bool IsShooting()
    {
        _isShooting = InputManager.Instance.OnFiring == 1;

        return _isShooting;
    }
}
