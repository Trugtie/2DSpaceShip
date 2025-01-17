using UnityEngine;

public class BtnInventory : BaseButton
{
    protected override void OnClick()
    {
        UIIventory.Instance.Toggle();
    }
}
