using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BaseMonobehaviour
{
    [Header(" Base Slider")]
    [SerializeField] protected Slider _slider;

    protected override void Start()
    {
        base.Start();
        AddOnValueChangeEvent();
    }

    protected virtual void AddOnValueChangeEvent()
    {
        _slider.onValueChanged.AddListener(OnValueChange);
    }

    protected abstract void OnValueChange(float newValue);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (_slider != null) return;
        _slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }
}
