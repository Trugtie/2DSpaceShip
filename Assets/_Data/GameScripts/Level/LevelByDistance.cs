using System;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header(" LevelByDistance Elements ")]
    [SerializeField] protected Transform _target;

    [Header(" Level By Distance Settings ")]
    [SerializeField] protected float _currentDistance;
    [SerializeField] protected float _distancePerLevel = 10f;

    protected virtual void FixedUpdate()
    {
        Leveling();
    }

    public virtual void SetTarget(Transform target)
    {
        _target = target;
    }

    protected virtual void Leveling()
    {
        if (_target == null) return;
        _currentDistance = Vector3.Distance(transform.position, _target.position);
        LevelSet(GetLevelByDistance(_currentDistance));
    }

    protected virtual int GetLevelByDistance(float distance)
    {
        return Mathf.FloorToInt(distance / _distancePerLevel);
    }

}
