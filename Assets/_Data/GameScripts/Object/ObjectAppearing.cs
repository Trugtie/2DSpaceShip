using System;
using UnityEngine;

public abstract class ObjectAppearing : BaseMonobehaviour
{
    [Header(" ObjectAppearing Settings ")]
    [SerializeField] protected bool _isAppearing = false;
    [SerializeField] protected bool _isAppeared = false;

    public bool IsAppearing => _isAppearing;
    public bool IsAppeared => _isAppeared;

    protected virtual void FixedUpdate()
    {
        Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        _isAppeared = true;
        _isAppearing = false;
    }
}
