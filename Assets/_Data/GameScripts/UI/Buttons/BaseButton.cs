using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : BaseMonobehaviour
{
    [Header(" BaseButton Elements ")]
    [SerializeField] protected Button _button;

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (_button != null) return;
        _button = GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }
}
