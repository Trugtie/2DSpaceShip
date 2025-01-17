using UnityEngine;

public class BtnCloseInventory : BaseButton
{
    protected override void OnClick()
    {
        UIIventory.Instance.Hide();
    }
}
