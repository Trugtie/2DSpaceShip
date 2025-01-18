using UnityEngine;

public class BtnInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
