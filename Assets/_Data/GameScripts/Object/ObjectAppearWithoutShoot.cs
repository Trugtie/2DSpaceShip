using System;
using UnityEngine;

public class ObjectAppearWithoutShoot : ShootableObjectAbtract, IObjectAppearObserver
{
    [Header(" ObjectAppearWithoutShoot Settings ")]
    [SerializeField] protected ObjectAppearing _objectAppearing;
    public ObjectAppearing ObjectAppearing => _objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        RegisterObjectAppearObserver();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjectAppearing();
    }

    private void LoadObjectAppearing()
    {
        if (_objectAppearing != null) return;

        _objectAppearing = GetComponent<ObjectAppearing>();

        Debug.LogWarning(transform.name + ": LoadObjectAppearing", gameObject);
    }

    private void RegisterObjectAppearObserver()
    {
        OnAppearStart();
        _objectAppearing.AddObserver(this);
    }

    public void OnAppearStart()
    {
        _shootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
        _shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        _shootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);
        _shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(true);
        _shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}
