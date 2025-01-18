using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnPressAlpha : BaseMonobehaviour
{
    protected virtual void Update()
    {
        CheckAlphaPress();
    }

    protected virtual void CheckAlphaPress()
    {
        if (InputHotkeyManager.Instance.isHotkey1) Debug.Log("isAlpha1");
        if (InputHotkeyManager.Instance.isHotkey2) Debug.Log("isAlpha2");
        if (InputHotkeyManager.Instance.isHotkey3) Debug.Log("isAlpha3");
        if (InputHotkeyManager.Instance.isHotkey4) Debug.Log("isAlpha4");
        if (InputHotkeyManager.Instance.isHotkey5) Debug.Log("isAlpha5");
        if (InputHotkeyManager.Instance.isHotkey6) Debug.Log("isAlpha6");
        if (InputHotkeyManager.Instance.isHotkey7) Debug.Log("isAlpha7");

    }
}
