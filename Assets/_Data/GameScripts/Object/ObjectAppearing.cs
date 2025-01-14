using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : BaseMonobehaviour
{
    [Header(" ObjectAppearing Settings ")]
    [SerializeField] protected bool _isAppearing = false;
    [SerializeField] protected bool _isAppeared = false;
    [SerializeField] protected List<IObjectAppearObserver> _observer = new List<IObjectAppearObserver>();

    public bool IsAppearing => _isAppearing;
    public bool IsAppeared => _isAppeared;

    protected override void Start()
    {
        base.Start();
        OnAppearStart();
    }

    protected virtual void FixedUpdate()
    {
        Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        _isAppeared = true;
        _isAppearing = false;
        OnAppearFinish();
    }

    public virtual void AddObserver(IObjectAppearObserver observer)
    {
        _observer.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObserver observer in _observer)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjectAppearObserver observer in _observer)
        {
            observer.OnAppearFinish();
        }
    }
}
