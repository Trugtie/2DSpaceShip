using UnityEngine;

public class ShipHPSlider : BaseSlider
{
    protected override void OnValueChange(float newValue)
    {
        Debug.Log(newValue);
    }
}
