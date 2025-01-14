using System;
using UnityEngine;

public class ObjectAppearingBigger : ObjectAppearing
{
    [Header(" ObjectAppearingBigger Settings ")]
    [SerializeField] protected float _currentScale = 0f;
    [SerializeField] protected float _speedScale = 0.01f;
    [SerializeField] protected float _startScale = 0.1f;
    [SerializeField] protected float _endScale = 1f;

    protected override void OnEnable()
    {
        base.OnEnable();
        InitObjectScale();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _currentScale = 0f;
        _speedScale = 0.01f;
        _startScale = 0.1f;
        _endScale = 1f;
    }

    private void InitObjectScale()
    {
        transform.parent.localScale = Vector3.zero;
        _currentScale = _startScale;
    }

    protected override void Appearing()
    {
        _currentScale += _speedScale;
        transform.parent.localScale = new Vector3(_currentScale, _currentScale, _currentScale);

        if (_currentScale >= _endScale) Appear();
    }

    public override void Appear()
    {
        base.Appear();
        transform.parent.localScale = new Vector3(_endScale, _endScale, _endScale);
    }
}
