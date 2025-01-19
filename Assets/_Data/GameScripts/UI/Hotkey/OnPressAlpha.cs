using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnPressAlpha : UIHotKeyAbtract
{
    protected virtual void Update()
    {
        CheckAlphaPress();
    }

    protected virtual void CheckAlphaPress()
    {
        if (InputHotkeyManager.Instance.isHotkey1) Press(0);
        if (InputHotkeyManager.Instance.isHotkey2) Press(1);
        if (InputHotkeyManager.Instance.isHotkey3) Press(2);
        if (InputHotkeyManager.Instance.isHotkey4) Press(3);
        if (InputHotkeyManager.Instance.isHotkey5) Press(4);
        if (InputHotkeyManager.Instance.isHotkey6) Press(5);
        if (InputHotkeyManager.Instance.isHotkey7) Press(6);
    }

    protected virtual void Press(int index)
    {
        ItemSlot itemSlot = UIHotkeyCtrl.ItemSlots[index];

        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();

        if (pressable == null) return;

        pressable.Pressed();
    }
}
