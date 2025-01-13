using System;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MapSetTarget();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTarget();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _distancePerLevel = 10f;
    }

    private void LoadTarget()
    {
        if (_target != null) return;

        PlayerCtrl playerCtrl = FindAnyObjectByType<PlayerCtrl>();

        if (playerCtrl == null)
        {
            Debug.LogError(transform.name + ": LoadTarget: Cant find player ctrl", gameObject);
            return;
        }

        _target = playerCtrl.CurrentShip.transform;

        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void MapSetTarget()
    {
        if (_target != null) return;
        Transform target = PlayerCtrl.Instance.CurrentShip.transform;
        SetTarget(target);
    }
}
